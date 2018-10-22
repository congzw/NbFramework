using Microsoft.Owin;
using NbCloud.Web.Areas.Auth.Identities;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace NbCloud.Web.Areas.Auth.Identities
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMyAuth(app);
        }
    }
}
