using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZaropaMVC.Startup))]
namespace ZaropaMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
