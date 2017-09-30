using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiXinDemo.Service.Model;

namespace WeiXinDemo.Service.Handler
{
    public class TextMsgHandler : IMsgHandler
    {
        public object Execute(string postData)
        {
            var request = XmlWeiXinHelper.Deserialize<TextMessageRequest>(postData);
           
            return new Response();
        }
        public void Request()
        {
           
        }

        public object Response()
        {
            var response = new TextMessageResponse
            {
                Content = "hello",
                CreateTime = DateTimeHelper.GetCurDateTime(),
                MsgType = request.MsgType,
                FromUserName = request.ToUserName,
                ToUserName = request.FromUserName
            };
        }
    }
}