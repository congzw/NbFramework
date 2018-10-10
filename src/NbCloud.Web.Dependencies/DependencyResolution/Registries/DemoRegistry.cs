using NbCloud.Web.Dependencies._Mock;
using NbFramework.Common.Data;
using NbFramework.Core._Mock;
using StructureMap;

namespace NbCloud.Web.Dependencies.DependencyResolution.Registries
{
    public class MockRegistry : Registry {

        public MockRegistry()
        {
            Scan(
                scan =>
                {
                    //1 One or more assemblies to scan for types
                    //2 One or more registration conventions
                    //3 Optionally, set filters to only include certain types or exclude other types from being processed by the scanning operation
                    
                    //1
                    scan.Assembly(typeof(IMockService).Assembly);
                    
                    //2
                    scan.WithDefaultConventions();
                    scan.SingleImplementationsOfInterface();
                    scan.RegisterConcreteTypesAgainstTheFirstInterface();
                    
                    //3(Optionally!)
                    //scan.AddAllTypesOf<IDemoService>();
                    ////FooDemoService will excluded!
                    //scan.Exclude(type => type.Name.Contains("Foo"));
                });

            //For<ITransactionManager>().Use<TransactionManager>();

            For(typeof(IVisualizer<>)).Use(typeof(DefaultVisualizer<>));
            // Register a specific visualizer for IssueCreated
            For<IVisualizer<IssueCreated>>().Use<IssueCreatedVisualizer>();
            
            //Inline config
            //For<IExample>().Use<Example>();
            //For<DemoAppService>().Use<DemoAppService>();
        }
    }
}
