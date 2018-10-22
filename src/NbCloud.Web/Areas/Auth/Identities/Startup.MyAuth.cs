using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using NbCloud.Web.Areas.Auth.Identities.DemoUsers;
using NbCloud.Web.Areas.Auth.Identities.MyIdentity;
using NbCloud.Web.Areas.Auth.Identities.MySignIn;
using Owin;

namespace NbCloud.Web.Areas.Auth.Identities
{
    public partial class Startup
    {
        public void ConfigureMyAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new MyUserManager(new MyIdentityStore(new DemoUserRepository())));
            app.CreatePerOwinContext<MySignInManager>((options, context) => new MySignInManager(context.GetUserManager<MyUserManager>(), context.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Auth/Account/Login"),
                Provider = new CookieAuthenticationProvider()
            });
        }
    }
}