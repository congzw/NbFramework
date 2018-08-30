using NbFramework.Common.Data;

namespace DemoSite.Domains.Mocks
{
    public interface IMockService
    {
        
    }
    public interface IDemoService : IMockService
    {

    }
    public interface IFooDemoService : IDemoService
    {
    }
    public interface IBarDemoService : IDemoService
    {
    }
    
    public class DemoService : BaseMockObject, IDemoService
    {
        public ISimpleRepository Repository { get; set; }
        public DemoService(ISimpleRepository simpleRepository)
        {
            Repository = simpleRepository;
        }
    }
    public class FooDemoService : BaseMockObject, IFooDemoService
    {
        public ISimpleRepository Repository { get; set; }
        public FooDemoService(ISimpleRepository simpleRepository)
        {
            Repository = simpleRepository;
        }
    }
    public class BarDemoService : BaseMockObject, IBarDemoService
    {
        public ISimpleRepository Repository { get; set; }
        public IFooDemoService FooDemoService { get; set; }

        public BarDemoService(ISimpleRepository simpleRepository, IFooDemoService fooDemoService)
        {
            Repository = simpleRepository;
            FooDemoService = fooDemoService;
        }
    }
}
