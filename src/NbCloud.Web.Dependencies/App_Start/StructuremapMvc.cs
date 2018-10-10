using System.Web.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using NbCloud.Web.Dependencies;
using NbCloud.Web.Dependencies.DependencyResolution;
using StructureMap;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructuremapMvc), "End")]

namespace NbCloud.Web.Dependencies
{
    public static class StructuremapMvc
    {
        public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

        public static void Start()
        {
            IContainer container = IoC.Initialize();
            StructureMapDependencyScope = new StructureMapDependencyScope(container);
            DependencyResolver.SetResolver(StructureMapDependencyScope);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
        }
        
        public static void End()
        {
            StructureMapDependencyScope.Dispose();
        }
    }
}