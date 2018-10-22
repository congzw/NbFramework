using System;
using System.Collections.Generic;

namespace NbCloud.Web.Areas.Auth.Identities.DemoUsers
{
    public interface IDemoUserRepository
    {
        IEnumerable<DemoUser> Query();
        void SaveOrUpdate(DemoUser demoUser);
        DemoUser Get(Guid userId);
    }
}