using System;
using System.Collections.Generic;
using System.Linq;

namespace NbFramework.WebApis.Selectors.ClassifiedSelectors
{
    public interface IClassifiedHttpControllerSelectorService
    {
        string Select(IList<string> apiControllerFullNames, string apiFolder, string controller, string area, params string[] category);
    }

    public class ClassifiedHttpControllerSelectorService : IClassifiedHttpControllerSelectorService
    {
        public string Select(IList<string> apiControllerFullNames, string apiFolder, string controller, string area, params string[] categories)
        {
            if (apiControllerFullNames == null)
            {
                throw new ArgumentNullException("apiControllerFullNames");
            }
            if (apiFolder == null)
            {
                throw new ArgumentNullException("apiFolder");
            }
            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }

            var joinCategory = "";
            if (categories != null)
            {
                var reverse = categories.Reverse();
                foreach (var category in reverse)
                {
                    if (!string.IsNullOrWhiteSpace(category))
                    {
                        //A.B.C.
                        joinCategory = category + "." + joinCategory;
                    }
                }
            }

            var controllerSearchingName = controller + "Controller";
            //XxxController
            if (!string.IsNullOrWhiteSpace(joinCategory))
            {
                //CATEGORY.XxxController
                controllerSearchingName = joinCategory.TrimEnd('.') + "." + controllerSearchingName;
            }

            //Api.CATEGORY.XxxController
            controllerSearchingName = apiFolder + "." + controllerSearchingName;

            if (!string.IsNullOrWhiteSpace(area))
            {
                //AREA.Api.CATEGORY.XxxController
                controllerSearchingName = area + "." + controllerSearchingName;
            }

            var apiControllerTypes = apiControllerFullNames.AsEnumerable();
            var results = apiControllerTypes
                .Where(x => x.IndexOf(controllerSearchingName, StringComparison.OrdinalIgnoreCase) != -1)
                .ToList();

            if (results.Count <= 1)
            {
                return results.SingleOrDefault();
            }

            //如果此时，没有指定area名称，用排除“Areas.”的方法，尝试过滤
            if (string.IsNullOrWhiteSpace(area))
            {
                results = results
                    .Where(x => x.IndexOf("Areas.", StringComparison.OrdinalIgnoreCase) == -1)
                    .ToList();
            }
            if (results.Count <= 1)
            {
                return results.SingleOrDefault();
            }

            //依然多条记录，则抛出异常
            throw new InvalidOperationException("找到多个匹配的ApiController:" + controllerSearchingName);
        }
    }
}
