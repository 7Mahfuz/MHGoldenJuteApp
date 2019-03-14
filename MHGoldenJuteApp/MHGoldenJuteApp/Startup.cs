using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MHGoldenJuteApp.Startup))]
namespace MHGoldenJuteApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
