using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(greenpagesdirectory.api.Startup))]

namespace greenpagesdirectory.api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
