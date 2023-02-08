using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(logintestMVC.Startup))]
namespace logintestMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
