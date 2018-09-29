using System.Web.Mvc;

namespace DemoSite.Controllers
{
    //render a raw razor view, only should be used on perpose!
    public class _PagesController : Controller
    {
        public ActionResult Show(string category, string view)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return View(view);
            }
            return View(category + "/" + view);
        }
    }
}
