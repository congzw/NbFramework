// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControllerConvention.cs" company="Web Advanced">
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

using StructureMap;
using StructureMap.Graph.Scanning;

namespace DemoSite.Infrastructure.DependencyResolution {
    using System.Web.Mvc;
    using StructureMap.Graph;
    using StructureMap.Pipeline;
    using StructureMap.TypeRules;

    public class ControllerConvention : IRegistrationConvention 
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            foreach (var type in types.AllTypes())
            {
                if (type.CanBeCastTo<Controller>() && !type.IsAbstract)
                {
                    //MVC: System.Web.Mvc.ControllerBase.VerifyExecuteCalledOnce()
                    //不能使用控制器“XxxController”的单个实例处理多个请求。如果正在使用自定义控制器工厂，请确保它为每个请求创建该控制器的新实例。]
                    registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
                }
            }
        }
    }
}