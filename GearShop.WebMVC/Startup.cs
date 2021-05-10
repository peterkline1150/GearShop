using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GearShop.WebMVC.Startup))]
namespace GearShop.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
