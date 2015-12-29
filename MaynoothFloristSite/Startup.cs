using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaynoothFloristSite.Startup))]
namespace MaynoothFloristSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
