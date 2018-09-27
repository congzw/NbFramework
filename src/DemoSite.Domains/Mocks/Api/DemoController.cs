using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DemoSite.Domains.Mocks.Api
{
    public class DemoController: ApiController
    {
        private readonly DemoAppService _demoAppService;

        public DemoController(DemoAppService demoAppService)
        {
            _demoAppService = demoAppService;
        }

        [HttpGet]
        public IHttpActionResult GetDemos()
        {
            var demos = _demoAppService.GetDemos();
            if (demos == null)
            {
                return NotFound();
            }
            return Ok(demos);
        }

        [HttpGet]
        public IHttpActionResult GetDemo(int id)
        {
            var demo = _demoAppService.GetDemo(id);
            if (demo == null)
            {
                return NotFound();
            }
            return Ok(demo);
        }
    }

    public class DemoAppService
    {
        private readonly IDemoService _demoService;

        public DemoAppService(IDemoService demoService)
        {
            _demoService = demoService;
        }

        public IReadOnlyList<DemoDto> GetDemos()
        {
            //todo
            var list = new List<DemoDto>();
            for (int i = 1; i <= 3; i++)
            {
                list.Add(new DemoDto() { Id = i, Name = "Demo" + i.ToString("00") });
            }
            return list;
        }

        public DemoDto GetDemo(int id)
        {
            return GetDemos().SingleOrDefault(x => x.Id == id);
        }
    }

    public class DemoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}