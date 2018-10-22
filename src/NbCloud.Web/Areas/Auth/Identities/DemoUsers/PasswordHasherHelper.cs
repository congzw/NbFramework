using System;
using Microsoft.AspNet.Identity;

namespace NbCloud.Web.Areas.Auth.Identities.DemoUsers
{
    internal static class PasswordHasherHelper
    {
        public static Func<IPasswordHasher> PasswordHasher = () => new PasswordHasher();
    }
}