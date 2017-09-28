using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeiXinDemo.Startup))]
namespace WeiXinDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
