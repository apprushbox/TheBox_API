using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheBoxApp_Web.Startup))]
namespace TheBoxApp_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
