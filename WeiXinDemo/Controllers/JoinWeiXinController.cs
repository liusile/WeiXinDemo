using Common;
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
using WeiXinDemo.Service;

namespace WeiXinDemo.Controllers
{
    public class JoinWeiXinController : Controller
    {
        [HttpGet]
        [ActionName("Index")]
        public void IndexGet(JoinWeiXinRequest request)
        {
            if (new ValideWeiXin().JoinWeiXin(request))
            {
                Response.Write(request.Echostr);
            }
        }
        [HttpPost]
        [ActionName("Index")]
        public void IndexPost()
        {
            string postStr;
            using (Stream stream = HttpContext.Request.InputStream)
            {
                Byte[] postBytes = new Byte[stream.Length];
                stream.Read(postBytes, 0, (Int32)stream.Length);
                postStr = Encoding.UTF8.GetString(postBytes);
            }

            if (!string.IsNullOrEmpty(postStr))
            {
                Object data = new WeixinMsgProcess().Execute(postStr);

                var result = XmlWeiXinHelper.SerializeForWeiXin(data);
                Response.Write(result);
            }
        }
    }
}