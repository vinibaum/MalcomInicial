using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webSiteInicial.Startup))]
namespace webSiteInicial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
