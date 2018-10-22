using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NbCloud.Web.Areas.Auth.Identities.DemoUsers;

namespace NbCloud.Web.Areas.Auth.Identities.MySignIn
{
    public class MySignInManager : SignInManager<DemoUser, Guid>
    {
        public MySignInManager(UserManager<DemoUser, Guid> userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager) { }

        public void SignOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
