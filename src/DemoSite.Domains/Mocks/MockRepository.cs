using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NbFramework.Common;
using NbFramework.Common.Data;
using NbFramework.Common.Extensions;

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
    
    public class TransactionManager : ITransactionManager
    {
        public TransactionTraceInfo TransactionInfo { get; set; }

        public TransactionManager()
        {
            var message = string.Format("[{0}]: Invoke Ctor() create new TransactionManager",
                UtilsDateTime.Current.Now().ToFormat());
            TransactionInfo = new TransactionTraceInfo();
            TransactionInfo.Infos.Add(message);

            LogMessage(message);
        }

        public void RequireNew()
        {
            var message = string.Format("[{0}]: Invoke RequireNew() when [Cancelled] is {1}", UtilsDateTime.Current.Now().ToFormat(), TransactionInfo.Cancelled);
            TransactionInfo.Infos.Add(message);
            TransactionInfo.Cancelled = false;
        }

        public void Commit()
        {
            var message = string.Format("[{0}]: Invoke Commit() and reset [Cancelled] from {1} to {2}",
                UtilsDateTime.Current.Now().ToFormat(), TransactionInfo.Cancelled, false);
            TransactionInfo.Infos.Add(message);
            TransactionInfo.Cancelled = false;
        }
        public void Cancel()
        {
            var message = string.Format("[{0}]: Invoke Cancel() and reset [Cancelled] from {1} to {2}",
                UtilsDateTime.Current.Now().ToFormat(), TransactionInfo.Cancelled, true);
            TransactionInfo.Infos.Add(message);
            LogMessage(message);

            TransactionInfo.Cancelled = true;
        }
        public void Dispose()
        {
            var message = string.Format("[{0}]: Invoke Dispose() and process transaction with [Cancelled: {1}]",
                UtilsDateTime.Current.Now().ToFormat(), TransactionInfo.Cancelled);
            TransactionInfo.Infos.Add(message);
            LogMessage(message);
        }

        private void LogMessage(string message)
        {
            UtilsLogger.LogMessage(this.GetType(), message);
        }
        public class TransactionTraceInfo
        {
            public TransactionTraceInfo()
            {
                Infos = new List<string>();
            }
            public IList<string> Infos { get; set; }
            public bool Cancelled { get; set; }
            public override string ToString()
            {
                if (Infos.Count == 0)
                {
                    return string.Format("Info: [Cancelled: {0}]", this.Cancelled);
                }

                var sb = new StringBuilder();
                foreach (var info in Infos)
                {
                    sb.AppendLine(info);
                }
                return sb.ToString();
            }
        }
    }
}