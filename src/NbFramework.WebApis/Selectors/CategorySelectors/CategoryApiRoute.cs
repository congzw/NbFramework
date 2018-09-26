using System.Web.Http;

namespace NbFramework.WebApis.Selectors.CategorySelectors
{
    public class CategoryApiRoute
    {
        //1 "CategoryRpcApi":
        //"api/{category}/{controller}/{action}"
        //2 "VersionCategoryRpcApi":
        //"api/v2/{category}/{controller}/{action}"
        //"api/v2_1/{category}/{controller}/{action}"
        //"api/v3/{category}/{controller}/{action}"
        //...

        public static string category = "category";
        public static string api_version = "api_version";

        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                "CategoryRpcApi",
                "api/{category}/{controller}/{action}",
                new { });


            config.Routes.MapHttpRoute(
                "VersionCategoryRpcApi",
                "api/{api_version}/{category}/{controller}/{action}",
                new { });
        }
    }
}