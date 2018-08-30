using System;
using System.Linq;
using NbFramework.Common.Data;

namespace DemoSite.Domains.Mocks
{
    public class SimpleRepository : BaseMockObject, ISimpleRepository
    {
        public ISession Session { get; set; }
        public ITransactionManager TransactionManager { get; set; }
        public SimpleRepository(ISession session, ITransactionManager transactionManager)
        {
            Session = session;
            TransactionManager = transactionManager;
        }

        public IQueryable<T> Query<T>() where T : INbEntity<Guid>
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id) where T : INbEntity<Guid>
        {
            throw new NotImplementedException();
        }

        public void Add<T>(params T[] entities) where T : INbEntity<Guid>
        {
            throw new NotImplementedException();
        }

        public void Add<T>(T entity, Guid? id = null) where T : INbEntity<Guid>
        {
            throw new NotImplementedException();
        }

        public void Update<T>(params T[] entities) where T : INbEntity<Guid>
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate<T>(params T[] entities) where T : INbEntity<Guid>
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(params T[] entities) where T : INbEntity<Guid>
        {
            throw new NotImplementedException();
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }
    }

    public interface ISession : IDisposable
    {
        string ForDebug { get; set; }
    }

    public class Session : BaseMockObject, ISession
    {
        public string ForDebug { get; set; }
    }
}