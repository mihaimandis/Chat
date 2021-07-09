using Chat.ChatServer.Log;
using Chat.db_layer;
using ChatServer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace ChatServer
{
    /// <summary>
    /// Summary description for ChatWebService
    /// </summary>
    [System.Web.Services.WebService(Namespace = "http://tempuri.org/")]
    [System.Web.Services.WebServiceBinding(ConformsTo = System.Web.Services.WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ChatWebService : System.Web.Services.WebService
    {
        public SoapHeader Authentication;

        DB_methods dbMethods = new DB_methods();
        static Dictionary<string, string> loggedInClientList = new Dictionary<string, string>();
        public ChatWebService()
        {
            this.dbMethods.connect(Settings.Default.dbConnectionString, Settings.Default.dbUserName, Settings.Default.dbPassword);
        }

        [SoapHeader("Authentication")]
        [System.Web.Services.WebMethod]
        public string LogIn(string nickName, string password)
        {
            LogWriterReader.writeLine("LogIn: nickName=" + nickName);
            string userPerrmissions = null;
            try
            {
                userPerrmissions = this.dbMethods.checkUserExists(nickName, password.GetHashCode().ToString());
                if (!string.IsNullOrEmpty(userPerrmissions))
                {
                    if (loggedInClientList.ContainsKey(nickName))
                        userPerrmissions = loggedInClientList[nickName];
                    else
                    {
                        userPerrmissions = userPerrmissions + "-" + new Guid();
                        loggedInClientList.Add(nickName, userPerrmissions);
                    }
                }
                LogWriterReader.writeLine("LogIn: nickName=" + nickName + ", Result=" + userPerrmissions);
            }
            catch (Exception ex)
            {
                LogWriterReader.writeLine(ex.ToString());
            }
            return userPerrmissions;
        }

        [SoapHeader("Authentication")]
        [System.Web.Services.WebMethod]
        public bool CheckUserExists(string permissions, string nickName, string toNickName)
        {
            LogWriterReader.writeLine("CheckUserExists: nickName=" + nickName + ", toNickName=" + toNickName);

            bool userExists = false;
            try
            {
                if (loggedInClientList[nickName] != permissions)
                    return false;
                userExists = dbMethods.checkUserExists(toNickName);
            }
            catch (Exception ex)
            {
                LogWriterReader.writeLine(ex.ToString());
            }

            LogWriterReader.writeLine("checkUserExists: nickName=" + nickName + ", toNickName=" + toNickName + ", Result=" + userExists.ToString());
            return userExists;
        }

        [SoapHeader("Authentication")]
        [System.Web.Services.WebMethod]
        public string ReceiveMessage(Chat.CommonClasses.Message message)
        {
            try
            {
                LogWriterReader.writeLine("ReceiveMessage: sender=" + message.sendeUserId + "receiverUserId" + message.receiverUserId);
                if (loggedInClientList[message.sendeUserId] == message.permissions)
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
    }
}
