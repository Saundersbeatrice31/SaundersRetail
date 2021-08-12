using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaundersRetail.WebMVC.Startup))]
namespace SaundersRetail.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
