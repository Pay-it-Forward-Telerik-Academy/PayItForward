using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PayItForward.WebForms.Startup))]
namespace PayItForward.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
