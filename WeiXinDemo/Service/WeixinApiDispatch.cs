using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WeiXinDemo.Service
{
    public class WeixinApiDispatch
    {
        public Object Execute(string postStr)
        {
             var xml= XElement.Parse(postStr);
             var dddd=   xml.Element("ToUserName");
             var ddddd = xml.Element("Content");
            
            return null;
        }

       
    }
}