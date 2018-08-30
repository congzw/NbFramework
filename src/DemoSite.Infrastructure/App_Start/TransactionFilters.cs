using System.Web.Mvc;
using NbFramework.Common;
using NbFramework.Common.Data;
using NbFramework.Common.Ioc;

namespace DemoSite.Infrastructure
{
    /// <summary>
    /// TransactionFilter For Mvc
    /// </summary>
    public class TransactionFilter : IExceptionFilter//ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var transactionManager = CoreServiceProvider.LocateService<ITransactionManager>();
            transactionManager.Cancel();
            LogMessage("Mvc Filter Ex: transactionManager.Cancel()" + filterContext.Exception.Message, transactionManager);
        }

        private void LogMessage(string message, ITransactionManager transactionManager)
        {
            UtilsLogger.LogMessage(string.Format("{0} > {1}", transactionManager.GetHashCode(), message));
        }
    }
}
