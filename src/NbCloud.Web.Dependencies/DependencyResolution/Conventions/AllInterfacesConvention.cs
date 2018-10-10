using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;

namespace NbCloud.Web.Dependencies.DependencyResolution.Conventions
{
    public class AllInterfacesConvention : IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            // Only work on concrete types
            var findTypes = types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed);
            foreach (var findType in findTypes)
            {
                // Register against all the interfaces implemented
                // by this concrete class
                var interfaces = findType.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    registry.For(@interface).Use(findType);
                }
            }
        }

        public override string ToString()
        {
            //for debug show
            //return base.ToString();
            return "Register multi interface for a concretes colsed class";
        }
    }
}
