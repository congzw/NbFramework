using System;
using System.Web.Http.Filters;
using NbFramework.Common.Data;
using NbFramework.Common.Ioc;

namespace NbFramework.WebApis
{
    /// <summary>
    /// TransactionFilter For WebApi
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)] //fix called twice!
    public class WebApiTransactionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var transactionManager = CoreServiceProvider.LocateService<ITransactionManager>();
            LogMessage("WebApi Filter Ex: transactionManager.Cancel() => " + context.Exception.Message);
            transactionManager.Cancel();
        }
        private void LogMessage(string message)
        {
            //UtilsLogger.Resolve().LogMessage(string.Format("{0} > {1}", "[WebApiTransactionFilter]=>", message));
        }
    }
}
