using System.Collections.Generic;
using System.Web.Mvc;

namespace DemoSite.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IDemoService _demoService;

        //public HomeController(IDemoService demoService)
        //{
        //    _demoService = demoService;
        //}

        //private readonly IList<IDemoService> _demoServices;
        //public HomeController(IList<IDemoService> demoServices)
        //{
        //    _demoServices = demoServices;
        //}

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
