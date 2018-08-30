using System.Web.Mvc;
using DemoSite.Infrastructure;

namespace DemoSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new TransactionFilter());
        }
    }
}
