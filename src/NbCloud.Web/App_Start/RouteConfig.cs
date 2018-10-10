﻿using System.Web.Mvc;
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
                defaults: new { controller = "_Pages", action = "Show", category = "", view = "Default" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index"}
            );
        }
    }
}