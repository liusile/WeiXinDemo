using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiXinDemo.Service.Handler
{
    public class BaseMsgHandler : IMsgHandler
    {
        public object Execute<>(string postData)
        {
            var request = XmlWeiXinHelper.Deserialize<TextMessageRequest>(postData);
        }
    }
}