using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXinApi.Model
{
    public class MenuCreateResponse
    {
        public string Errcode { get; set; }
        public string Errmsg { get; set; }
        public bool IsSuccess => Errcode == "0" ? true : false;
    }
}
