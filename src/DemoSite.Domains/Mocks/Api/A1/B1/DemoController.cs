using System;
using System.Web.Http;

namespace DemoSite.Domains.Mocks.Api.A1.B1
{
    public class DemoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetDemos()
        {
            return Ok("OK => " +DateTime.Now);
        }
    }
}
