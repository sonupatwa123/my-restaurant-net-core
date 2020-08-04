using System.Collections.Generic;
using System.Xml.Serialization;

namespace MyRestaurant.Model.Entities
{
    [XmlRoot(ElementName = "Modules")]
    public class Modules
    {
        [XmlElement(ElementName = "Success")]
        public Success Success { get; set; }
        [XmlElement(ElementName = "Error")]
        public Error Error { get; set; }
    }
    [XmlRoot(ElementName = "Success")]
    public class Success
    {
        [XmlElement(ElementName = "Message")]
        public List<Message> Message { get; set; }
    }

    [XmlRoot(ElementName = "Error")]
    public class Error
    {
        [XmlElement(ElementName = "Message")]
        public List<Message> Message { get; set; }
    }
    [XmlRoot(ElementName = "Message")]
    public class Message
    {
        private string id;
        private string code;
        private string info;
        private string messageDetail;
        private string type;
        [XmlElement(ElementName = "Id")]
        public string Id
        {
            get { return id; }
            set
            {
                id = value.Trim();
            }
        }
        [XmlElement(ElementName = "code")]
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value.Trim();
            }
        }
        [XmlElement(ElementName = "info")]
        public string Info
        {
            get
            {
                return info;
            }
            set
            {
              info = value.Trim();
            }
        }
        [XmlElement(ElementName = "message")]
        public string message
        {
            get
            {
                return messageDetail;
            }
            set
            {
                this.messageDetail = value.Trim();
            }
        }
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value.Trim();
            }
        }
    }
}
