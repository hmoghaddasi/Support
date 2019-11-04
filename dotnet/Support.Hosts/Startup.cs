using Microsoft.Owin;
using Owin;
using Startup = Support.Hosts.Startup;

[assembly: OwinStartup(typeof(Startup))]

namespace Support.Hosts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureWebApi(app);
        }
    }
}