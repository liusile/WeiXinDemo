using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WeiXinDemo.Service.Model
{
    [XmlRoot("xml")]
    public class TextMessageRequest:MessageBase
    {
        public string MsgId { get; set; }
        public string Content { get; set; }
    }
}