using System;

namespace Chat.CommonClasses
{
    public class Message
    {
        public string messageId;
        public string sendeUserId;
        public string receiverUserId;
        public DateTime dateTimeSent;
        public DateTime dateTimeReceived;
        public string messageText;
        public object messageObject;
        public bool receiverReceivedFl;
        public string permissions;
    }
}
