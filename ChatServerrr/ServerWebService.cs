using Chat.CommonClasses;
using Chat.db_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Web.Services;
using Chat.ChatServer.Log;

namespace Chat.ChatServer
{
    [WebService(Name = "ChatWebService")]
    public class ServerWebService
    {
        DB_methods dbMethods = new DB_methods();
        Dictionary<string, string> loggedInClientList = new Dictionary<string, string>();
        public ServerWebService() {

            this.dbMethods.connect(ChatServer.Properties.Settings.Default.dbConnectionString,
                Boolean.Parse(ChatServer.Properties.Settings.Default.useDbIntegratedSecurity),
                ChatServer.Properties.Settings.Default.dbUserName,
                ChatServer.Properties.Settings.Default.dbPassword);
        }

        [WebMethod]
        public string LogIn(string nickName, string password)
        {
            LogWriterReader.writeLine("LogIn: nickName=" + nickName);
            string userPerrmissions=null;
            try
            {
                userPerrmissions = this.dbMethods.checkUserExists(nickName, password.GetHashCode().ToString());
                if (string.IsNullOrEmpty(userPerrmissions))
                {
                    userPerrmissions = userPerrmissions + "-" + new Guid();
                    loggedInClientList.Add(nickName, userPerrmissions);
                }
                LogWriterReader.writeLine("LogIn: nickName=" + nickName + ", Result=" + userPerrmissions);
            }
            catch (Exception ex)
            {
                LogWriterReader.writeLine(ex.ToString());
            }
            return userPerrmissions;
        }

        [WebMethod]
        public string ReceiveMessage(string userPerrmissions,CommonClasses.Message message) {
            try
            {
                LogWriterReader.writeLine("ReceiveMessage: sender=" + message.sendeUserId + "receiverUserId" + message.receiverUserId);
                if (loggedInClientList[message.sendeUserId] == userPerrmissions)
                {
                    dbMethods.insertMessage(message.sendeUserId, message.receiverUserId,
                        message.dateTimeSent, DateTime.MinValue,
                        message.messageText, null, false);
                }
            }
            catch (Exception ex)
            {
                LogWriterReader.writeLine(ex.ToString());
            }
            return "0";
        }

        [WebMethod]
        public bool CheckUserExists(string nickName)
        {
            bool userExists = false;
            try
            {
                LogWriterReader.writeLine("checkUserExists: nickName=" + nickName);
                userExists = dbMethods.checkUserExists(nickName);
                LogWriterReader.writeLine("checkUserExists: nickName=" + nickName+", Result="+userExists.ToString());

            }
            catch (Exception ex)
            {
                LogWriterReader.writeLine(ex.ToString());
            }
            return userExists;
        }


    }
}
