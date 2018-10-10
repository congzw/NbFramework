using System;
using System.Linq;
using NbFramework.Common.Data;
using NbFramework.Core._Mock;

namespace NbCloud.Web.Dependencies._Mock
{
    public class SimpleRepository : BaseMockObject, ISimpleRepository
    {
        public ISession Session { get; set; }
        public SimpleRepository(ISession session)
        {
            Session = session;
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
}