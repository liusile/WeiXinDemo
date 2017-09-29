using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiXinApi.Model;

namespace WeiXinApi
{
    public class MenuWeiXin
    {
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <returns></returns>
        public bool Create(MenuCreateRequest request)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/menu/create?access_token={ WeiXinConst.Access_token }";
           
            var response = new Common.HttpHelper().Post<MenuCreateResponse>(url, request);
            if (response.IsSuccess)
            {
                return true;
            }
            else
            {
                throw  new Exception(response.Errmsg);
            }
        }
        /// <summary>
        /// 查询菜单
        /// </summary>
        public MenuInfo Search()
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/menu/get?access_token={ WeiXinConst.Access_token }";

            return new Common.HttpHelper().Get<MenuInfo>(url); 
        }
    }
}
