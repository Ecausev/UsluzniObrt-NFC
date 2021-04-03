using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UsluzniObrt.MVC.Startup))]
namespace UsluzniObrt.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
