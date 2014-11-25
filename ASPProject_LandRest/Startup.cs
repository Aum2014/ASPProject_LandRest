using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPProject_LandRest.Startup))]
namespace ASPProject_LandRest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
