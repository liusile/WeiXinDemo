using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace WeiXinDemo.Service.Model
{
    [XmlRoot(ElementName = "xml")]
    public class TextMessageResponse:MessageBase
    {
        public string Content { get; set; }
    }

}