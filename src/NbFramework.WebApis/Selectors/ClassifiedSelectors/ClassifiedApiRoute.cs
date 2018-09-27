using System.Web.Http;

namespace NbFramework.WebApis.Selectors.ClassifiedSelectors
{
    public class ClassifiedApiRoute
    {
        //Api/Admin/RunningRecord/GetAll
        //Api/Admin/A/RunningRecord/GetAll
        //Api/Admin/A.B/RunningRecord/GetAll
        //Api/Admin/A.B.A/RunningRecord/GetAll
        //...

        public static void Register(HttpConfiguration config)
        {
            //todo process config with di

            //AreaCategoryRpcApi

            config.Routes.MapHttpRoute(
                "AreaCategoryRpcApi",
                "api/{area}/{category}/{controller}/{action}",
                new { });

            //AreaRpcApi
            config.Routes.MapHttpRoute(
                 name: "AreaRpcApi",
                 routeTemplate: "api/{area}/{controller}/{action}",
                 defaults: new { }
             );

            //RpcApi
            config.Routes.MapHttpRoute(
                name: "RpcApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { }
                );
        }
    }
}