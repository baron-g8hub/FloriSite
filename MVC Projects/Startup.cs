using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Projects.Startup))]
namespace MVC_Projects
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
