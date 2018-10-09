using System.Web.Mvc;
using System.Web.Routing;

namespace NbCloud.Web
{
    public class MyMainEntry
    {
        public static void Init()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
