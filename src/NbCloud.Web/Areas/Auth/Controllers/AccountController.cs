using System.Web.Mvc;
using NbCloud.Web.Areas.Auth.AppServices;

namespace NbCloud.Web.Areas.Auth.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountAppService _accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }
        //todo return url
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVo vo)
        {
            if (ModelState.IsValid)
            {
                var result = _accountAppService.ValidateLogin(vo);
                if (result.Success)
                {
                    //todo
                    //FormAuth.SingIn();
                    return Redirect("~/");
                }
                ModelState.AddModelError("", "无效的登录凭证");
                ModelState.AddModelError("", result.Message);
            }
            return View(vo);
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
