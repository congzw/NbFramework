using System.Web.Mvc;
using NbCloud.Web.Areas.Auth.ViewModels;

namespace NbCloud.Web.Areas.Auth.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return Content("Account Login From Auth");
        }

        [HttpPost]
        public ActionResult Login(LoginVo loginVo)
        {
            return Content("Account Login From Auth");
        }

        public ActionResult Logout()
        {
            return Content("Account Logout From Auth");
        }
    }
}
