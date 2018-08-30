// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Diagnostics;
using CommonServiceLocator;
using DemoSite.Domains.Mocks;
using DemoSite.Infrastructure.Mocks;
using NbFramework.Common.Ioc;

namespace DemoSite.Infrastructure.DependencyResolution {
	using StructureMap;
	
	public static class IoC {
		public static IContainer Initialize()
		{
			var container =  new Container(c =>
            {
				c.Scan(_ =>
				{
					//assemblies
					_.AssembliesAndExecutablesFromApplicationBaseDirectory(assembly =>
					{
						var name = assembly.GetName().Name;
						return name.StartsWith("DemoSite", StringComparison.OrdinalIgnoreCase) || name.StartsWith("NbFramework");
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