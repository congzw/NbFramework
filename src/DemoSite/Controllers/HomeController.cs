using System.Web.Mvc;
using DemoSite.Domains.Demo;

namespace DemoSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDemoService _demoService;

        public HomeController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        //demo for each tenant infos(per database)!
        public ActionResult Index()
        {
            return View();
        }

        //demo for all tenants manage
        public ActionResult Tenants()
        {
            return View();
        }
    }
}
