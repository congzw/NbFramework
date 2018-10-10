using System.Web.Mvc;

namespace NbCloud.Web.Areas.AdminSg.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("Home Index From AdminSg");
        }
    }
}
