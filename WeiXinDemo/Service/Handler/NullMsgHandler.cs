using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiXinDemo.Service.Handler
{
    public class NullMsgHandler : IMsgHandler
    {
        public object Execute(string postData)
        {
            return null;
        }
    }
}