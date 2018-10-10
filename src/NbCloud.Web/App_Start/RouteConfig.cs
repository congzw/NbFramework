using System.Web.Mvc;
using System.Web.Routing;

namespace NbCloud.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default_Pages",
                url: "Pages/{category}/{view}",
                defaults: new { controller = "_Pages", action = "Show", category = "", view = "Default" },
                namespaces: new[] { typeof(RouteConfig).Namespace + ".Controllers" }
            );
            
            routes.MapRoute(
                "Common_Default",
                "Common/{controller}/{action}",
                new[] { typeof(RouteConfig).Namespace + ".Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index"},
                namespaces: new[] { typeof(RouteConfig).Namespace + ".Controllers" }
            );
        }
    }
}
