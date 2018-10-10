using System.Web.Mvc;

namespace NbCloud.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("Home Index From Admin");
        }
    }
}
