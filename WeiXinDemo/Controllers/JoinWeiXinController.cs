using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WeiXinApi;
using WeiXinApi.Model;

namespace WeiXinDemo.Controllers
{
    public class JoinWeiXinController : Controller
    {
        // GET: JoinWeiXinIn
        public void Index(JoinWeiXinRequest request)
        {
            if (HttpContext.Request.HttpMethod == "Get")
            {

                if (new ValideWeiXin().JoinWeiXin(request))
                {
                    Response.Write(request.Echostr);
                }
            }
            else
            {
                string postString = string.Empty;
                using (Stream stream = HttpContext.Request.InputStream)
                {
                    Byte[] postBytes = new Byte[stream.Length];
                    stream.Read(postBytes, 0, (Int32)stream.Length);
                    postString = Encoding.UTF8.GetString(postBytes);
                }

                if (!string.IsNullOrEmpty(postString))
                {
                    Execute(postString);
                }
            }
        }
        private void Execute(string postStr)
        {
            StringBuilder buffer = new StringBuilder();
            WeixinApiDispatch dispatch = new WeixinApiDispatch();
            Object responseContent = dispatch.Execute(postStr);
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(object));
            using (TextWriter writer = new StringWriter(buffer))
            {
                x.Serialize(writer, responseContent);
            }
            Response.Write(buffer);
        }
    }
}