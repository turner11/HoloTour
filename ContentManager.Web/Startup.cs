using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContentManager.Web.Startup))]
namespace ContentManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
