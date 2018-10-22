using System;
using Microsoft.AspNet.Identity;

namespace NbCloud.Web.Areas.Auth.Identities.DemoUsers
{
    public class DemoUser : IUser<Guid>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Nick { get; set; }
    }
}
