using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace NbFramework.WebApis.Selectors
{
    public class ClassifiedHttpControllerSelector : DefaultHttpControllerSelector
    {
        private const string AreaRouteVariableName = "area";
        private const string CategoryRouteVariableName = "category";
        private const string ControllerFolderPrefix = "Api";

        private readonly Lazy<INamespaceApiControllerSelector> _namespaceApiSelectorLazy;
        private readonly HttpConfiguration _configuration;
        private readonly Lazy<ConcurrentDictionary<string, Type>> _apiControllerTypes;

        public ClassifiedHttpControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
            //check instance count, todo
            _configuration = configuration;
            _apiControllerTypes = new Lazy<ConcurrentDictionary<string, Type>>(GetAllControllerTypes);
            _namespaceApiSelectorLazy = new Lazy<INamespaceApiControllerSelector>(() => WebApiSelectorHelper.Resolve());
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
            string area = GetRouteValueByName(request, AreaRouteVariableName);
            string category = GetRouteValueByName(request, CategoryRouteVariableName);
            string controller = GetControllerName(request);
            var type = TryGetControllerType(area, category, controller);
            if (type == null)
            {
                return null;
            }
            return new HttpControllerDescriptor(_configuration, controller, type);
        }

        private Type TryGetControllerType(string area, string category, string controller)
        {
            var typeDic = _apiControllerTypes.Value;
            var controllers = typeDic.Keys.ToList();
            var namespaceApiControllerSelector = _namespaceApiSelectorLazy.Value;

            try
            {
                var theOne = namespaceApiControllerSelector.Select(controllers, ControllerFolderPrefix, controller, area, category);
                if (theOne != null)
                {
                    return typeDic[theOne];
                }
            }
            catch (Exception ex)
            {
                WebApiSelectorHelper.Error(string.Format("Select ApiController For {0}.{1}.{2} Ex!", area, category, controller), ex);
                return null;
            }

            return null;
        }
    }
}
