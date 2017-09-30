using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WeiXinDemo.Service.Handler;
using WeiXinDemo.Service.Model;

namespace WeiXinDemo.Service
{
    public class WeixinMsgProcess
    {
        public Object Execute(string postData)
        {
            IMsgHandler msgHandler;

            switch (GetMsgType(postData))
            {
                case MsgType.TEXT:
                    msgHandler = new TextMsgHandler();
                    break;
                default:
                    msgHandler = new NullMsgHandler();
                    break;
            }

            return msgHandler.Execute(postData);

        }
        public MsgType GetMsgType(string postData)
        {
            var xml = XElement.Parse(postData);
            var strMsgType = xml.Element("MsgType").Value;
            return (MsgType)Enum.Parse(typeof(MsgType), strMsgType, true);
        }

    }
}