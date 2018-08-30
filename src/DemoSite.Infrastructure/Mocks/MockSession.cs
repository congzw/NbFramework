using System;

namespace DemoSite.Domains.Mocks
{
    public interface ISession : IDisposable
    {
        string ForDebug { get; set; }
    }

    public class Session : BaseMockObject, ISession
    {
        public string ForDebug { get; set; }
    }
}
