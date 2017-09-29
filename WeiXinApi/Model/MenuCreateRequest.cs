using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXinApi.Model
{
    public class MenuCreateRequest
    {
        public List<Button> button { get; set; }
    }

    public class Button
    {
        public ButtonType type { get; set; }
        public string name { get; set; }
        //click等点击类型必须 菜单KEY值，用于消息接口推送
        public string key { get; set; }
        public string url { get; set; }
        //小程序的appid（仅认证公众号可配置）
        public string appid { get; set; }
        //小程序的页面路径
        public string pagepath { get; set; }
        //调用新增永久素材接口返回的合法media_id
        public string media_id { get; set; }
        public List<Button> sub_button { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ButtonType
    {
        //click表示点击类型，
        
         click,
        //view表示网页类型
         view,
        //miniprogram表示小程序类型
        miniprogram
    }
}
