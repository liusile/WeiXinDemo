using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeiXinDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXinDemo.Service.Tests
{
    [TestClass()]
    public class WeixinApiDispatchTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
           string xmlData = @"<xml><ToUserName><![CDATA[gh_2fcf9662217c]]></ToUserName>
                    <FromUserName><![CDATA[oUwuTsws5bKe6sdNn-a3CC6LKSJk]]></FromUserName>
                    <CreateTime>1506698017</CreateTime>
                    <MsgType><![CDATA[text]]></MsgType>
                    <Content><![CDATA[来来来]]></Content>
                    <MsgId>6471218708403765285</MsgId>
                    </xml>";
            var dispatch = new WeixinApiDispatch();
            var xml = dispatch.Execute(xmlData);
            Assert.Fail();
        }
    }
}