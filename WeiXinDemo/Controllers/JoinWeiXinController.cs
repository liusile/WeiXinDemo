using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiXinApi;
using WeiXinApi.Model;

namespace WeiXinDemo.Controllers
{
    public class JoinWeiXinController : Controller
    {
        // GET: JoinWeiXinIn
        public string Index(JoinWeiXinRequest request)
        {
            if (new ValideWeiXin().JoinWeiXin(request))
            {
                return request.Echostr;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}