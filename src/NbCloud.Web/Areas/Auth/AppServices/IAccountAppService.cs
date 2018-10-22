using System.ComponentModel.DataAnnotations;
using NbFramework.Common;
using NbFramework.Common.AppServices;

namespace NbCloud.Web.Areas.Auth.AppServices
{
    public interface IAccountAppService : IAppService
    {
        MessageResult ValidateLogin(LoginVo vo);
    }

    public class LoginVo
    {
        [Display(Name = "User name")]
        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
