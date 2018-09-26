using System;
using System.Collections.Generic;
using System.Linq;

namespace NbFramework.WebApis.Selectors.CategorySelectors
{
    public interface ICategoryHttpControllerSelectorService
    {
        string Select(IList<string> apiControllerFullNames, string version, string category, string controller);
    }

    public class CategoryHttpControllerSelectorService : ICategoryHttpControllerSelectorService
    {
        public string Select(IList<string> apiControllerFullNames, string version, string category, string controller)
        {
            if (apiControllerFullNames == null)
            {
                throw new ArgumentNullException("apiControllerFullNames");
            }
            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }


            var controllerSearchingName = controller + "Controller";
            //XxxController
            if (!string.IsNullOrWhiteSpace(category))
            {
                //CATEGORY.XxxController
                controllerSearchingName = category.TrimEnd('.') + "." + controllerSearchingName;
            }

            if (!string.IsNullOrWhiteSpace(version))
            {
                //V2.CATEGORY.XxxController
                controllerSearchingName = version.TrimEnd('.') + "." + controllerSearchingName;
            }

            var apiControllerTypes = apiControllerFullNames.AsEnumerable();
            var results = apiControllerTypes
                .Where(x => x.IndexOf(controllerSearchingName, StringComparison.OrdinalIgnoreCase) != -1)
                .ToList();

            if (results.Count <= 1)
            {
                return results.SingleOrDefault();
            }

            //多条记录，则抛出异常
            throw new InvalidOperationException("找到多个匹配的ApiController:" + controllerSearchingName);
        }
    }
}
