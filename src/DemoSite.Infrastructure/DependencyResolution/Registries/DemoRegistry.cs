using DemoSite.Domains.Demo;
using StructureMap;

namespace DemoSite.Infrastructure.DependencyResolution.Registries
{
    public class DemoRegistry : Registry {

        public DemoRegistry()
        {
            //Scan(
            //    scan =>
            //    {
            //        scan.Assembly(typeof(IDemoService).Assembly);
            //        scan.WithDefaultConventions();
            //    });

            //For<IExample>().Use<Example>();
            //For<IDemoService>().Use<DemoService>();
            //For<IDemoService>().Add<FooDemoService>();

            For<IDemoService>().Use<FooDemoService>();
        }
    }
}
