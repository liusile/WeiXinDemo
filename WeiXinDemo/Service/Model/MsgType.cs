using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiXinDemo.Service.Model
{
    public enum MsgType
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        TEXT,
        /// <summary>
        /// 图片消息
        /// </summary>
        IMAGE,
        /// <summary>
        /// 语音消息
        /// </summary>
        VOICE,
        /// <summary>
        /// 视频消息
        /// </summary>
        VIDEO,
        /// <summary>
        /// 小视频消息
        /// </summary>
        SHORTVIDEO,
        /// <summary>
        /// 地理位置消息
        /// </summary>
        LOCATION,
        /// <summary>
        /// 链接消息
        /// </summary>
        LINK,
        /// <summary>
        /// 事件消息
        /// </summary>
        EVENT
    }
}