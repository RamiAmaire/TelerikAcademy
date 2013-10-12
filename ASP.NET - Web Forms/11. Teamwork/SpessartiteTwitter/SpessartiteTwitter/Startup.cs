using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpessartiteTwitter.Startup))]
namespace SpessartiteTwitter
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
