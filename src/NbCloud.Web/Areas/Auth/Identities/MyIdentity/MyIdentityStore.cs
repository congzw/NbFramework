using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using NbCloud.Web.Areas.Auth.Identities.DemoUsers;

namespace NbCloud.Web.Areas.Auth.Identities.MyIdentity
{
    public class MyIdentityStore : IUserStore<DemoUser, Guid>, IUserPasswordStore<DemoUser, Guid>, IUserLockoutStore<DemoUser, Guid>, IUserTwoFactorStore<DemoUser, Guid>
    {
        private readonly IDemoUserRepository _demoUserRepository;

        public MyIdentityStore(IDemoUserRepository _demoUserRepository)
        {
            this._demoUserRepository = _demoUserRepository;
        }

        public Task CreateAsync(DemoUser demoUser)
        {
            return Task.Run(() => _demoUserRepository.SaveOrUpdate(demoUser));
        }

        public Task UpdateAsync(DemoUser demoUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(DemoUser demoUser)
        {
            throw new NotImplementedException();
        }

        public Task<DemoUser> FindByIdAsync(Guid userId)
        {
            return Task.Run(() => _demoUserRepository.Get(userId));
        }

        public Task<DemoUser> FindByNameAsync(string userName)
        {
            return Task.Run(() => _demoUserRepository.Query().SingleOrDefault(x => x.UserName == userName));
        }

        public Task SetPasswordHashAsync(DemoUser demoUser, string passwordHash)
        {
            return Task.Run(() => demoUser.PasswordHash = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(DemoUser demoUser)
        {
            return Task.Run(() => demoUser.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(DemoUser demoUser)
        {
            return Task.Run(() => true);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(DemoUser demoUser)
        {
            throw new NotImplementedException();
            //return Task.FromResult(DateTimeOffset.MinValue);
        }

        public Task SetLockoutEndDateAsync(DemoUser demoUser, DateTimeOffset lockoutEnd)
        {
            return Task.FromResult(0);
        }

        public Task<int> IncrementAccessFailedCountAsync(DemoUser user)
        {
            return Task.FromResult(0);
        }

        public Task ResetAccessFailedCountAsync(DemoUser demoUser)
        {
            return Task.FromResult(0);
        }

        public Task<int> GetAccessFailedCountAsync(DemoUser user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(DemoUser demoUser)
        {
            return Task.Run(() => false);
        }

        public Task SetLockoutEnabledAsync(DemoUser demoUser, bool enabled)
        {
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(DemoUser demoUser, bool enabled)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(DemoUser demoUser)
        {
            return Task.Run(() => false);
        }
    }
}
