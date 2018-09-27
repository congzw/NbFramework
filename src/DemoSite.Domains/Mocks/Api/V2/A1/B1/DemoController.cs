using System;
using System.Web.Http;

namespace DemoSite.Domains.Mocks.Api.V2.A1.B1
{
    public class DemoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetDemos()
        {
            return Ok("V2 OK => " +DateTime.Now);
        }
    }
}
