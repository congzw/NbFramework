using System.Web.Mvc;
using NbFramework.Common;
using NbFramework.Common.Data;
using NbFramework.Common.Ioc;

namespace DemoSite.Infrastructure
{
    //Repace TransactionFilter with IHttpModule (mvc & webapi) !
    #region temp

    //filters.Add(new TransactionFilter());
    //IHttpModule.Error += (sender, args) =>
    //{
    //    var transactionManager = StructuremapMvc.StructureMapDependencyScope.GetInstance<ITransactionManager>();
    //    transactionManager.Cancel();
    //};

    /// <summary>
    /// TransactionFilter For Mvc
    /// </summary>
    public class TransactionFilter : IExceptionFilter
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

    #endregion
}
