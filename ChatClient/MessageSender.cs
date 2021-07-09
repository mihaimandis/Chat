using Chat.ChatClient.Serializer;
using Chat.CommonClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ChatClient
{
    public class MessageSender
    {
        bool connected = false;
        string permissions = null;
        IPAddress ipAddress;
        int port;
        string userName;
        string password;
        string serviceHttpAddress;

        Dictionary<string, string> userList = new Dictionary<string, string>();


        public MessageSender(IPAddress ipAddress, int port, string userName, string password)
        {
            this.ipAddress = ipAddress;
            this.port = port;
            this.userName = userName;
            this.password = password;
            this.serviceHttpAddress = "http://" + ipAddress + ":" + port.ToString() + "/ChatServer/ChatWebService.asmx";
        }

        public string LogIn()
        {
            string requestBody = "nickName=" + this.userName+"&password="+this.password;
            string operation = "LogIn";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceHttpAddress +"/" + operation);
            setRequestData(operation, requestBody,ref request);
            
            Task<WebResponse> response = request.GetResponseAsync();
            byte[] responseBodyBytes = new Byte[(int)response?.Result?.ContentLength];
            int cbytes = response.Result.GetResponseStream().Read(responseBodyBytes, 0, (int)response?.Result?.ContentLength);
            string responseBody = new Regex(@">(.*?)<").Match(Encoding.UTF8.GetString(responseBodyBytes)).Groups[1].Value;

            if (cbytes != 0 && !string.IsNullOrEmpty(responseBody))
            {
                this.connected = true;
                this.permissions = responseBody;
            }
            return responseBody;
        }

        public bool CheckUserExists(string toUserName)
        {
            if (!this.connected) return false;

            string operation = "CheckUserExists";
            string requestBody = "permissions=" + this.permissions + "&nickName=" + this.userName + "&toNickName=" + toUserName;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceHttpAddress + "/" + operation);
            setRequestData(operation, requestBody, ref request);

            Task<WebResponse> response = request.GetResponseAsync();
            byte[] responseBodyBytes = new Byte[(int)response?.Result?.ContentLength];
            int cbytes = response.Result.GetResponseStream().Read(responseBodyBytes, 0, (int)response?.Result?.ContentLength);
            string responseBody = new Regex(@">(.*?)<").Match(Encoding.UTF8.GetString(responseBodyBytes)).Groups[1].Value;

            if (cbytes != 0 && !string.IsNullOrEmpty(responseBody))
            {
                this.connected = true;
            }
            return bool.Parse(responseBody);
        }
        public bool Connected { get => connected;}
        public string Permissions { get => permissions;}

        public bool sendMessage(string toUserName, string text)
        {
            if (!this.connected || string.IsNullOrEmpty(text)) return false;
            Message message = new Message();
            message.messageId = string.Empty;
            message.messageText = text;
            message.permissions = this.permissions;
            message.receiverUserId = toUserName;
            message.dateTimeSent = DateTime.Now;
            message.receiverReceivedFl = false;

            string operation = "ReceiveMessage";
            string requestBody = XmlSerialiser.SerializeObjectToString(message);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceHttpAddress + "/" + operation);
            setRequestData(operation, requestBody, ref request,"xml");
            //request.Headers.Add("SOAPAction", "http://tempuri.org/ReceiveMessage");
            //request.ContentType = "application//xml; charset=utf-8";
            //request.Credentials = new System.Net.NetworkCredential(this.userName, this.password);
            //request.ContentLength = requestBody.Length;
            //request.Method = "POST";


            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                var xmlSerialiser = new XmlSerializer(typeof(string));
                streamWriter.Write(requestBody);
            }

            Task<WebResponse> response = request.GetResponseAsync();
            byte[] responseBodyBytes = new Byte[(int)response?.Result?.ContentLength];
            int cbytes = response.Result.GetResponseStream().Read(responseBodyBytes, 0, (int)response?.Result?.ContentLength);
            string responseBody;
            /*using (WebClient client = new WebClient())
            {
                client.Headers.Add("SOAPAction", "\"http://tempuri.org/ReceiveMessage\"");
                client.Headers.Add("Content-Type", "text/xml; charset=utf-8");
                var data = Encoding.UTF8.GetBytes(requestBody);
                var result = client.UploadData("http://" + ipAddress + ":" + port.ToString() + "/ChatServer/ChatWebService.asmx", data);
                responseBody = Encoding.Default.GetString(result);
            }*/
            responseBody = new Regex(@">(.*?)<").Match(Encoding.UTF8.GetString(responseBodyBytes)).Groups[1].Value;
            
            if (/*cbytes != 0 &&*/ !string.IsNullOrEmpty(responseBody))
            {
               this.connected = true;
            }
            return bool.Parse(responseBody);
        }

        private void setRequestData(string operation, string requestBody, ref HttpWebRequest request,string contentType= "x-www-form-urlencoded") {

            request.Referer = "http://" + ipAddress + ":" + port.ToString() + "/ChatServer/ChatWebService.asmx?op="+ operation;
            request.UserAgent = "Mozilla/5.0+(Windows+NT+6.3;+Win64;+x64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/91.0.4472.124+Safari/537.36";
            request.ContentType = "application/"+ contentType;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentLength = requestBody.Length;
            request.Credentials = new System.Net.NetworkCredential(this.userName, this.password);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                var xmlSerialiser = new XmlSerializer(typeof(string));
                streamWriter.Write(requestBody);
            }
        }
    }
}
