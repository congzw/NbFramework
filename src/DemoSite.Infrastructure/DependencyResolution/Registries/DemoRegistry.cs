using DemoSite.Domains.Demo;
using StructureMap;

namespace DemoSite.Infrastructure.DependencyResolution.Registries
{
    public class DemoRegistry : Registry {

        public DemoRegistry()
        {
            Scan(
                scan =>
                {
                    //1 One or more assemblies to scan for types
                    //2 One or more registration conventions
                    //3 Optionally, set filters to only include certain types or exclude other types from being processed by the scanning operation
                    
                    //1
                    scan.Assembly(typeof(IDemoService).Assembly);
                    
                    //2
                    scan.WithDefaultConventions();
                    scan.SingleImplementationsOfInterface();
                    scan.RegisterConcreteTypesAgainstTheFirstInterface();
                    
                    //3(Optionally!)
                    //scan.AddAllTypesOf<IDemoService>();
                    ////FooDemoService will excluded!
                    //scan.Exclude(type => type.Name.Contains("Foo"));
                });


            For(typeof(IVisualizer<>)).Use(typeof(DefaultVisualizer<>));
            // Register a specific visualizer for IssueCreated
            For<IVisualizer<IssueCreated>>().Use<IssueCreatedVisualizer>();

            //For<IExample>().Use<Example>();

            //Inline!
            //For<IDemoService>().Use<DemoService>();
            //For<IDemoService>().Add<FooDemoService>();
            //For<IDemoService>().Add<BarDemoService>();
        }
    }
}
