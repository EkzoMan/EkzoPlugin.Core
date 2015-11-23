using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EkzoPlugin.CoreSite.Startup))]
namespace EkzoPlugin.CoreSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
