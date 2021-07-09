using Chat.CommonClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Chat.db_layer
{
    public class DB_methods
    {
        SqlConnection sqlConnection;
        bool is_connected = false;
        string connectionString;

        public void connect(string connectionString, string userName,string password) {
            this.connectionString = connectionString;

            if (!this.connectionString.Contains("Integrated Security=True"))
            this.connectionString += ";User ID=" + userName + ";Password=" + password + ";";

            this.connect_t();
        }

        private void connect_t() {
            sqlConnection = new SqlConnection(this.connectionString);
            sqlConnection.Open();
        }

        public void closeConnection()
        {
            this.sqlConnection.Close();
        }

        public bool checkUserExists(string nickName) {
            if (sqlConnection.State != ConnectionState.Open) this.connect_t();

            SqlCommand cmd = new SqlCommand("get_user", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NICK_NAME", nickName));
            var nickNameReturn = cmd.ExecuteScalar();
            return nickNameReturn == null ? false : true;
        }

        public string checkUserExists(string nickName,string pwdHash)
        {
            if (sqlConnection.State != ConnectionState.Open) this.connect_t();

            SqlCommand cmd = new SqlCommand("get_user_with_pwd", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NICK_NAME", nickName));
            cmd.Parameters.Add(new SqlParameter("@PWD_HASH", pwdHash));
            var permissions = cmd.ExecuteScalar();
            if (permissions == null) return null;
            return permissions.ToString();
        }
        public int insertUser(string nickName, string pwdHash, string permissions)
        {
            if (sqlConnection.State != ConnectionState.Open) this.connect_t();

            SqlCommand cmd = new SqlCommand("insert_user", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NICK_NAME", nickName));
            cmd.Parameters.Add(new SqlParameter("@PWD_HASH", pwdHash));
            cmd.Parameters.Add(new SqlParameter("@PERMISSIONS", permissions));
            int crows= cmd.ExecuteNonQuery();
            return crows;
        }

        public int updateUser(string nickName, string pwdHash, string permissions)
        {
            if (sqlConnection.State != ConnectionState.Open) this.connect_t();

            SqlCommand cmd = new SqlCommand("update_user", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NICK_NAME", nickName));
            cmd.Parameters.Add(new SqlParameter("@PWD_HASH", pwdHash));
            cmd.Parameters.Add(new SqlParameter("@PERMISSIONS", permissions));
            int crows = cmd.ExecuteNonQuery();
            return crows;
        }

        public int deleteUser(string nickName)
        {
            if (sqlConnection.State != ConnectionState.Open) this.connect_t();

            SqlCommand cmd = new SqlCommand("delete_user", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NICK_NAME", nickName));
            int crows = cmd.ExecuteNonQuery();
            return crows;
        }

        public int insertMessage(string senderUserId, string receiverUserId,
	        DateTime dateTimeSent, DateTime dateTimeReceived,
	        string messageText, Image messageObject,
            bool receiverReceivedFl)
        {
            if (sqlConnection.State != ConnectionState.Open) this.connect_t();

            SqlCommand cmd = new SqlCommand("insert_message", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@SENDER_USER_ID", senderUserId));
            cmd.Parameters.Add(new SqlParameter("@RECEIVER_USER_ID", receiverUserId));
            cmd.Parameters.Add(new SqlParameter("@DATE_TIME_SENT", dateTimeSent));
            cmd.Parameters.Add(new SqlParameter("@DATE_TIME_RECEIVED", dateTimeReceived));
            cmd.Parameters.Add(new SqlParameter("@MESSAGE_TEXT", messageText));
            cmd.Parameters.Add(new SqlParameter("@MESSAGE_OBJECT", messageObject));
            cmd.Parameters.Add(new SqlParameter("@RECEIVER_RECEIVED_FL", receiverReceivedFl));
            int crows = cmd.ExecuteNonQuery();
            return crows;
        }

        public int updateMessageSent(string messageId, DateTime dateTimeReceived, bool receiverReceivedFl)
        {
            if (sqlConnection.State != ConnectionState.Open) this.connect_t();

            SqlCommand cmd = new SqlCommand("insert_message", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MESSAGE_ID", messageId));
            cmd.Parameters.Add(new SqlParameter("@DATE_TIME_RECEIVED", dateTimeReceived));
            cmd.Parameters.Add(new SqlParameter("@RECEIVER_RECEIVED_FL", receiverReceivedFl));
            int crows = cmd.ExecuteNonQuery();
            return crows;
        }

        public List<Message> getMessagesByUsers(string senderUserId, string receiverUserId)
        {
            if (sqlConnection.State != ConnectionState.Open) this.connect_t();

            SqlCommand cmd = new SqlCommand("get_messages_by_users", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@SENDER_USER_ID", senderUserId));
            cmd.Parameters.Add(new SqlParameter("@RECEIVER_USER_ID", receiverUserId));

            List<Message> messages = new List<Message>();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    messages.Add(new Message
                    {
                        messageId = sdr["MESSAGE_ID"].ToString(),
                        sendeUserId = sdr["SENDER_USER_ID"].ToString(),
                        receiverUserId = sdr["RECEIVER_USER_ID"].ToString(),
                        dateTimeSent = DateTime.Parse(sdr["DATE_TIME_SENT"].ToString()),
                        dateTimeReceived = DateTime.Parse(sdr["DATE_TIME_RECEIVED"].ToString()),
                        messageText = sdr["MESSAGE_TEXT"].ToString(),
                        messageObject = null,
                        receiverReceivedFl = sdr["RECEIVER_RECEIVED_FL"].ToString()=="Y"?true:false,
                    }) ;
                }
            }
            return messages;
        }
    }
}
