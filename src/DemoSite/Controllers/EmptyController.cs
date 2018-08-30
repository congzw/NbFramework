using System.Web.Mvc;

namespace DemoSite.Controllers
{
    public class EmptyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
