using System;
using NbFramework.Core._Mock;

namespace NbCloud.Web.Dependencies._Mock
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
