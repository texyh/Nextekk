using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClientManagement.Web.Startup))]
namespace ClientManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
