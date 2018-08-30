using System;
using DemoSite.Domains.Mocks;

namespace DemoSite.Infrastructure.Mocks
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
