using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(greenpages.web.Startup))]
namespace greenpages.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
