using System.Web;
using NbFramework.Common;
using NbFramework.Common.Data;
using NbFramework.Core._Mock;
using StructureMap.Web.Pipeline;

namespace NbCloud.Web.Dependencies.DependencyResolution
{
    public class StructureMapScopeModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) =>
            {
                StructuremapMvc.StructureMapDependencyScope.CreateNestedContainer();
                var transactionManager = StructuremapMvc.StructureMapDependencyScope.GetInstance<ITransactionManager>();

                //lazy mode, no need start tx;
                LogMessage("BeginRequest: " + transactionManager.GetHashCode());
            };
            context.EndRequest += (sender, e) =>
            {
                HttpContextLifecycle.DisposeAndClearAll();
                StructuremapMvc.StructureMapDependencyScope.DisposeNestedContainer();
                LogMessage("EndRequest");
            };

            context.Error += (sender, args) =>
            {
                var transactionManager = StructuremapMvc.StructureMapDependencyScope.GetInstance<ITransactionManager>();
                transactionManager.Cancel();
                LogMessage("Request Ex: transactionManager.Cancel()");
            };
        }
        public void Dispose()
        {
        }
        private void LogMessage(string message)
        {
            if (BaseMockObject.TraceDebug())
            {
                UtilsLogger.LogMessage(this.GetType(), message);
            }
        }
    }
}