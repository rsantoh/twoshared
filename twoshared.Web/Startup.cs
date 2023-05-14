using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(twoshared.Web.Startup))]
namespace twoshared.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
