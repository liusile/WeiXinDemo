using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiXinApi;
using WeiXinApi.Model;

namespace WeiXinDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateButton_Menu()
        {
            try
            {
                var request = new MenuCreateRequest()
                {
                    button=new List<Button>()
                    {
                        new Button() {name="test4",type = ButtonType.click,key="test"}
                    }
                };
                new MenuWeiXin().Create(request);
                ViewBag.Msg = "创建菜单成功！";
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View("Index");
        }
        public ActionResult SearchButton_Menu()
        {
            try
            {
                var menu = new MenuWeiXin().Search();
                ViewBag.Msg = JsonConvert.SerializeObject(menu);
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View("Index");
        }
    }
}