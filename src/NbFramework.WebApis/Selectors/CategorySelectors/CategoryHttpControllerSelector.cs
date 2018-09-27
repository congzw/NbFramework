using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using NbFramework.WebApis.Selectors.ClassifiedSelectors;

namespace NbFramework.WebApis.Selectors.CategorySelectors
{
    public class CategoryHttpControllerSelector : DefaultHttpControllerSelector
    {
        private readonly HttpConfiguration _configuration;
        private readonly Lazy<ConcurrentDictionary<string, Type>> _apiControllerTypes;
        private ICategoryHttpControllerSelectorService _httpControllerSelectorService;

        public ICategoryHttpControllerSelectorService HttpControllerSelectorService
        {
            get { return _httpControllerSelectorService ?? (_httpControllerSelectorService = new CategoryHttpControllerSelectorService()); }
            set { _httpControllerSelectorService = value; }
        }

        public CategoryHttpControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
            //check instance count => result: only 1
            _configuration = configuration;
            _apiControllerTypes = new Lazy<ConcurrentDictionary<string, Type>>(GetAllControllerTypes);
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            return GetApiController(request);
        }

        private static string GetRouteValueByName(HttpRequestMessage request, string strRouteName)
        {
            var data = request.GetRouteData();
            if (data.Values.ContainsKey(strRouteName))
            {
                return data.Values[strRouteName] as string;
            }
            return null;
        }

        private static ConcurrentDictionary<string, Type> GetAllControllerTypes()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Dictionary<string, Type> types = assemblies.SelectMany(a => a.GetTypes()
                .Where(t => !t.IsAbstract
                    && t.Name.EndsWith(ControllerSuffix, StringComparison.OrdinalIgnoreCase)
                    && typeof(IHttpController).IsAssignableFrom(t)))
                    .ToDictionary(t => t.FullName, t => t);
            return new ConcurrentDictionary<string, Type>(types);
        }

        private HttpControllerDescriptor GetApiController(HttpRequestMessage request)
        {
            string version = GetRouteValueByName(request, CategoryApiRoute.api_version);
            string category = GetRouteValueByName(request, CategoryApiRoute.category);
            string controller = GetControllerName(request);
            var type = TryGetControllerType(version, category, controller);
            if (type == null)
            {
                return null;
            }
            return new HttpControllerDescriptor(_configuration, controller, type);
        }

        private Type TryGetControllerType(string version, string category, string controller)
        {
            var typeDic = _apiControllerTypes.Value;
            var controllers = typeDic.Keys.ToList();

            try
            {
                var theOne = HttpControllerSelectorService.Select(controllers, version, category, controller);
                if (theOne != null)
                {
                    return typeDic[theOne];
                }
            }
            catch (Exception ex)
            {
                WebApiSelectorHelper.Error(string.Format("Select ApiController For {0}.{1} Ex!", category, controller), ex);
                return null;
            }

            return null;
        }
    }
}
