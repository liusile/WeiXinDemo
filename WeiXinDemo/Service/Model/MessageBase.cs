using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WeiXinDemo.Service.Model
{
    public class MessageBase
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public long CreateTime { get; set; }
        public string MsgType { get; set; }
        public MsgType MsgTypeEnum => (MsgType)Enum.Parse(typeof(MsgType), MsgType, true);


    }
}