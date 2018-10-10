using System.Web.Mvc;

namespace NbCloud.Web.Areas._Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("Home Index From Demo");
        }
    }
}
