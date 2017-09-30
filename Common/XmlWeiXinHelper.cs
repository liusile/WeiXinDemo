using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Common
{
    public static class XmlWeiXinHelper
    {

        public static T Deserialize<T>(string input) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public static string SerializeForWeiXin(Object Object)
        {
            if (Object == null)
            {
                return "";
            }
            StringBuilder str=new StringBuilder();
            str.Append("<xml>");
            var  props = Object.GetType().GetProperties();
            foreach (var prop in props)
            {
                string name = prop.Name;
                string value = prop.GetValue(Object)?.ToString();
                str.Append($"<{name}><![CDATA[{value}]]></{name}>");   
            }
            str.Append("</xml>");
            return str.ToString();
        }

       
    }
}
