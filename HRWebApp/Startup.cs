using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRWebApp.Startup))]
namespace HRWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
