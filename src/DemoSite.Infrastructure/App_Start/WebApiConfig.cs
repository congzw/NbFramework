using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using NbFramework.WebApis;
using NbFramework.WebApis.Selectors;
using NbFramework.WebApis.Selectors.ClassifiedSelectors;

namespace DemoSite.Infrastructure
{
    public static class WebApiConfig
    {
        public static void RegisterRoute(HttpConfiguration config)
        {
            //todo process config with di
            
            //Api/Admin/RunningRecord/GetAll
            //Api/Admin/A/RunningRecord/GetAll
            //Api/Admin/A.B/RunningRecord/GetAll
            //Api/Admin/A.B.A/RunningRecord/GetAll

            //AreaCategoryRpcApi
            
            config.Routes.MapHttpRoute(
                "AreaCategoryRpcApi",
                "api/{area}/{category}/{controller}/{action}", 
                new {});

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

        public static void RegisterGlobalFilters(HttpConfiguration config)
        {
            //事务控制WebApi
            config.Filters.Add(new WebApiTransactionFilter());
        }

        public static void ReplaceSelector(HttpConfiguration config)
        {
            //replace IHttpControllerSelector
            config.Services.Replace(typeof(IHttpControllerSelector), new ClassifiedHttpControllerSelector(config));
        }

        public static void SetFormatters(HttpConfiguration config)
        {
            //JsonSerializerSettings serializerSetting = new JsonSerializerSettings
            //{
            //    ContractResolver = new NHibernateContractResolver(),
            //    //循环问题
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //};
            //config.Formatters.JsonFormatter.SerializerSettings = serializerSetting;

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

            ////jsonp 支持
            //config.AddJsonpFormatter();
        }

        public static void SetCors(HttpConfiguration config)
        {
            ////https://msdn.microsoft.com/en-us/magazine/dn532203.aspx
            ////config.EnableCors();
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
