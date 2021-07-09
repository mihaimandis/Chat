use database1
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE get_user
	@nick_name nvarchar(50)
AS
BEGIN
	if(@nick_name is null) raiserror ('@nick_name is null',1,-20000);

	SET NOCOUNT ON;
	select nick_name from dbo.users where NICK_NAME = @nick_name and IS_DELETED <> 'Y';
	return;
END
GO

use database1
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE get_user_with_pwd
	@nick_name nvarchar(50),
	@pwd_hash nvarchar(50)
AS
BEGIN
	if(@nick_name is null) raiserror ('@nick_name is null',1,-20000);
	if(@pwd_hash is null) raiserror ('@pwd_hash is null',1,-20000);

	SET NOCOUNT ON;
	select permissions from dbo.users where NICK_NAME = @nick_name and PWD_HASH = @pwd_hash and (IS_DELETED is null or IS_DELETED != 'Y');
	return;
END
GO

use database1
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE insert_user 
	@nick_name nvarchar(50),
	@pwd_hash nvarchar(50),
	@permissions nvarchar(50) = 'user'
AS
BEGIN
	DECLARE @last_user_id numeric;

	select @last_user_id = coalesce(cast(max(user_id) as numeric),0) from dbo.users;
	if(@nick_name is null) raiserror ('@nick_name is null',1,-20000);
	if(@pwd_hash is null) raiserror ('@pwd_hash is null',1,-20000);

	SET NOCOUNT ON;
	insert into dbo.users values (cast(@last_user_id+1 as nvarchar(50)),@nick_name,@pwd_hash,getdate(),@permissions,null);
	commit;
END
GO

use database1
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE update_user 
	@nick_name nvarchar(50),
	@pwd_hash nvarchar(50),
	@permissions nvarchar(50) = 'user'
AS
BEGIN
	DECLARE @user_id numeric;
	if(@nick_name is null) raiserror ('@nick_name is null',1,-20000);
	if(@pwd_hash is null) raiserror ('@pwd_hash is null',1,-20000);

	select @user_id = user_id  from dbo.users where nick_name = @nick_name;

	update dbo.USERS set pwd_hash = @pwd_hash,permissions=@permissions where user_id = @user_id and (IS_DELETED is null or IS_DELETED != 'Y');
	commit;
END
GO

use database1
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE delete_user 
	@nick_name nvarchar(50)
AS
BEGIN
	DECLARE @user_id numeric;
	if(@nick_name is null) raiserror ('@nick_name is null',1,-20000);

	update dbo.USERS set IS_DELETED = 'Y' where user_id = @user_id;
	commit;
END
GO

/*-----------------------------------*/


use database1
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE insert_message 
	@SENDER_USER_ID nvarchar(50),
	@RECEIVER_USER_ID nvarchar(50),
	@DATE_TIME_SENT datetime,
	@DATE_TIME_RECEIVED datetime,
	@MESSAGE_TEXT nvarchar(1000),
	@MESSAGE_OBJECT image,
	@RECEIVER_RECEIVED_FL nvarchar(1) = 'N'
AS
BEGIN
	DECLARE @last_message_id numeric;

	select @last_message_id = cast(max(MESSAGE_ID) as numeric) from dbo.MESSAGES;
	if(@SENDER_USER_ID is null) raiserror ('@SENDER_USER_ID is null',1,-20000);
	if(@RECEIVER_USER_ID is null) raiserror ('@RECEIVER_USER_ID is null',1,-20000);
	if(@RECEIVER_USER_ID is null) raiserror ('@DATE_TIME_SENT is null',1,-20000);

	SET NOCOUNT ON;
	insert into dbo.messages values (cast(@last_message_id+1 as nvarchar),@SENDER_USER_ID,@RECEIVER_USER_ID,@DATE_TIME_SENT,null,@MESSAGE_TEXT,@MESSAGE_OBJECT,@RECEIVER_RECEIVED_FL);
	commit;
	return @last_message_id + 1
END
GO

use database1
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE update_message_sent
	@message_id nvarchar(50),
	@DATE_TIME_RECEIVED datetime,
	@RECEIVER_RECEIVED_FL nvarchar(1) = 'Y'
AS
BEGIN
	DECLARE @last_message_id numeric;

	select @last_message_id = cast(max(MESSAGE_ID) as numeric) from dbo.MESSAGES;
	if(@message_id is null) raiserror ('@message_id is null',1,-20000);
	if(@DATE_TIME_RECEIVED is null) raiserror ('@DATE_TIME_RECEIVED is null',1,-20000);
	
	SET NOCOUNT ON;
	update dbo.messages set DATE_TIME_RECEIVED = @DATE_TIME_RECEIVED, @RECEIVER_RECEIVED_FL = @RECEIVER_RECEIVED_FL where message_id = @message_id;
	commit;
END
GO

use database1
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE get_messages_by_users
	@SENDER_USER_ID nvarchar(50),
	@RECEIVER_USER_ID datetime
AS
BEGIN
	if(@SENDER_USER_ID is null) raiserror ('@SENDER_USER_ID is null',1,-20000);
	if(@RECEIVER_USER_ID is null) raiserror ('@RECEIVER_USER_ID is null',1,-20000);

	select * from dbo.messages where SENDER_USER_ID = @SENDER_USER_ID and RECEIVER_USER_ID = @RECEIVER_USER_ID;
	return
END
GO

