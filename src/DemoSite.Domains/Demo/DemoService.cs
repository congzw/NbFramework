namespace DemoSite.Domains.Demo
{
    public interface IDemoService
    {

    }

    public interface IFooDemoService : IDemoService
    {
    }
    public interface IBarDemoService : IDemoService
    {
    }

    public class DemoService : IDemoService
    {

    }
    public class FooDemoService : IFooDemoService
    {

    }
    public class BarDemoService : IBarDemoService
    {

    }
}
