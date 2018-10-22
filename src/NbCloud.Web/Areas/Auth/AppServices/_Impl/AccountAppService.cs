using NbFramework.Common;

namespace NbCloud.Web.Areas.Auth.AppServices._Impl
{
    public class AccountAppService : IAccountAppService
    {
        public MessageResult ValidateLogin(LoginVo vo)
        {
            //todo
            if (vo.Username == "admin" && vo.Password == "admin")
            {
                return MessageResult.ValidateResult(true);
            }
            return MessageResult.ValidateResult();
        }
    }
}
