using System;
using System.Web.Mvc;

namespace DemoSite.Controllers
{
    public class EmptyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ex()
        {
            throw new Exception("whatever");
        }
    }
}
