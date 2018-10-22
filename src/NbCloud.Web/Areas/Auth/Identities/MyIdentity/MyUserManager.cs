using System;
using Microsoft.AspNet.Identity;
using NbCloud.Web.Areas.Auth.Identities.DemoUsers;

namespace NbCloud.Web.Areas.Auth.Identities.MyIdentity
{
    public class MyUserManager : UserManager<DemoUser, Guid>
    {
        public MyUserManager(IUserStore<DemoUser, Guid> store) : base(store)
        {
            UserValidator = new UserValidator<DemoUser, Guid>(this);
            PasswordValidator = new PasswordValidator() { RequiredLength = 6 };
            PasswordHasher = new PasswordHasher();
        }
    }
}