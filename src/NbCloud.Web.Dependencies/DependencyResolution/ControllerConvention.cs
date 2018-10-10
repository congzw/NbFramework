using System.Web.Mvc;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;
using StructureMap.Pipeline;
using StructureMap.TypeRules;

namespace NbCloud.Web.Dependencies.DependencyResolution {

    public class ControllerConvention : IRegistrationConvention 
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            foreach (var type in types.AllTypes())
            {
                if (type.CanBeCastTo<Controller>() && !type.IsAbstract)
                {
                    //MVC: System.Web.Mvc.ControllerBase.VerifyExecuteCalledOnce()
                    //A single instance of controller 'XxxController' cannot be used to handle multiple requests. 
                    //If a custom controller factory is in use, make sure that it creates a new instance of the controller for each request.
                    registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
                }
            }
        }
    }
}