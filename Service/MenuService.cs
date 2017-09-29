using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiXinApi;
using WeiXinApi.Model;

namespace Service
{
    public class MenuService
    {
        public MenuWeiXin MenuWeixin =new MenuWeiXin();
        public bool Create()
        {
            var request = new MenuCreateRequest
            {
                Button = new List<Button>()
                {
                   new Button() {Type=ButtonType.Click,Name="test",Key="test" }
                }
            };
            return MenuWeixin.Create(request);
        }
    }
}
