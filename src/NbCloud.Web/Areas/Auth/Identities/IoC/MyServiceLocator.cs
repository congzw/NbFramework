using System.Web;
using Microsoft.AspNet.Identity.Owin;
using NbCloud.Web.Areas.Auth.Identities.MyIdentity;
using NbCloud.Web.Areas.Auth.Identities.MySignIn;

namespace NbCloud.Web.Areas.Auth.Identities.IoC
{
    //should pick a real di container to solve depencency injection!
    public class MyServiceLocator
    {
        public static MyUserManager GetUserManager()
        {
            return HttpContext.Current.GetOwinContext().Get<MyUserManager>();
        }

        public static MySignInManager GetSignInManager()
        {
            return HttpContext.Current.GetOwinContext().Get<MySignInManager>();
        }
    }
}
