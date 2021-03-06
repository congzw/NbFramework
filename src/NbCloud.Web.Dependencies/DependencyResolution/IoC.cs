using System;
using System.Diagnostics;
using CommonServiceLocator;
using NbCloud.Web.Dependencies._Mock;
using NbFramework.Common.Ioc;
using NbFramework.Core._Mock;
using StructureMap;

namespace NbCloud.Web.Dependencies.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            var container = new Container(c =>
            {
                c.Scan(_ =>
                {
                    //assemblies
                    _.AssembliesAndExecutablesFromApplicationBaseDirectory(assembly =>
                    {
                        var name = assembly.GetName().Name;
                        return name.StartsWith("NbFramework") || name.StartsWith("NbCloud");
                    });

                    //registries
                    _.LookForRegistries();
                });

                //global register
                c.For<IServiceLocator>().Use<StructureMapDependencyScope>().Singleton();
            });

            CoreServiceProvider.CurrentFunc = () => container.GetInstance<IServiceLocator>();

            BaseMockObject.ExcludedNames.Add(typeof(TransactionManager.TransactionTraceInfo).Name);
            ShowDebugInfo(container);

            return container;
        }

        private static void ShowDebugInfo(Container container)
        {
            var whatDidIScan = container.WhatDidIScan();
            Debug.Write(whatDidIScan);

            var whatDoIHave = container.WhatDoIHave();
            Debug.Write(whatDoIHave);
        }
    }
}