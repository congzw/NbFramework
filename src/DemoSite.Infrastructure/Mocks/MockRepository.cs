using System;
using System.Linq;
using NbFramework.Common.Data;

namespace DemoSite.Domains.Mocks
{
    public class SimpleRepository : BaseMockObject, ISimpleRepository
    {
        public ISession Session { get; set; }
        public SimpleRepository(ISession session)
        {
            Session = session;
        }

        //public ISession Session { get; set; }
        //public TransactionManager TransactionManager { get; set; }
        //public SimpleRepository(TransactionManager transactionManager)
        //{
        //    Session = transactionManager.Session;
        //    TransactionManager = transactionManager;
        //}

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
}