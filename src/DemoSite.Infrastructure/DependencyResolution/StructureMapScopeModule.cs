using System.Web;
using DemoSite.Domains.Mocks;
using NbFramework.Common;
using NbFramework.Common.Data;
using StructureMap.Web.Pipeline;

namespace DemoSite.Infrastructure.DependencyResolution {

    public class StructureMapScopeModule : IHttpModule {

        public void Dispose()
        {
        }

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