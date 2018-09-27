using System.Web.Http;

namespace NbFramework.WebApis.Selectors.CategorySelectors
{
    public class CategoryApiRoute
    {
        //0 "RpcApi":
        //"api/{controller}/{action}"
        //1 "CategoryRpcApi":
        //"api/{category}/{controller}/{action}"
        //"api/{v2_1.category}/{controller}/{action}"

        public static string category = "category";

        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                "RpcApi",
                "api/{controller}/{action}",
                new { });

            config.Routes.MapHttpRoute(
                "CategoryRpcApi",
                "api/{category}/{controller}/{action}",
                new { });
        }
    }
}