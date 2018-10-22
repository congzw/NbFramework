using System.Web.Mvc;
using NbCloud.Web.Areas.Auth.ViewModels;

namespace NbCloud.Web.Areas.Auth.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVo vo)
        {
            return Content("Account Login From Auth");
        }

        public ActionResult Logout()
        {
            return Content("Account Logout From Auth");
        }

        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Register(RegisterVo vo)
        //{
        //    return Content("Account Register From Auth");
        //}
    }
}
