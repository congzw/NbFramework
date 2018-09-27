using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using NbFramework.WebApis;
using NbFramework.WebApis.Selectors.CategorySelectors;

namespace DemoSite.Infrastructure
{
    public static class WebApiConfig
    {
        public static void Init()
        {
            var config = GlobalConfiguration.Configuration;
            RegisterRoute(config);
            RegisterGlobalFilters(config);
            ReplaceSelector(config);
            SetFormatters(config);
            SetCors(config);
        }

        public static void RegisterRoute(HttpConfiguration config)
        {
            CategoryApiRoute.Register(config);
        }

        public static void RegisterGlobalFilters(HttpConfiguration config)
        {
            //事务控制WebApi
            config.Filters.Add(new WebApiTransactionFilter());
        }

        public static void ReplaceSelector(HttpConfiguration config)
        {
            //replace IHttpControllerSelector
            config.Services.Replace(typeof(IHttpControllerSelector), new CategoryHttpControllerSelector(config));
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
