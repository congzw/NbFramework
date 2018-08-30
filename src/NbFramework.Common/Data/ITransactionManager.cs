using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NbFramework.Common.Extensions;

namespace NbFramework.Common.Data
{
    /// <summary>
    /// IUnitOfWork
    /// </summary>
    public interface ITransactionManager : IDisposable
    {
        /// <summary>
        /// 立刻触发事务处理。根据当前上下文，提交或者回滚当前事务，然后开启一个新的事务
        /// </summary>
        void RequireNew();
        /// <summary>
        /// 标示为提交，销毁实例时触发实际的操作
        /// </summary>
        void Commit();
        /// <summary>
        /// 标示为取消，销毁实例时触发实际的操作
        /// </summary>
        void Cancel();
    }

    #region null impl
    
    public class NullTransactionManager : ITransactionManager
    {
        public TransactionTraceInfo TransactionInfo { get; set; }

        public NullTransactionManager()
        {
            TransactionInfo = new TransactionTraceInfo();
            TransactionInfo.Infos.Add(string.Format("[{0}]: Invoke Ctor() create new TransactionManager", UtilsDateTime.Current.Now().ToFormat()));
        }

        public void RequireNew()
        {
            TransactionInfo.Infos.Add(string.Format("[{0}]: Invoke RequireNew() when [Cancelled] is {1}", UtilsDateTime.Current.Now().ToFormat(), TransactionInfo.Cancelled));
            TransactionInfo.Cancelled = false;
        }

        public void Commit()
        {
            TransactionInfo.Infos.Add(string.Format("[{0}]: Invoke Commit() and reset [Cancelled] from {1} to {2}", UtilsDateTime.Current.Now().ToFormat(), TransactionInfo.Cancelled, false));
            TransactionInfo.Cancelled = false;
        }
        public void Cancel()
        {
            TransactionInfo.Infos.Add(string.Format("[{0}]: Invoke Cancel() and reset [Cancelled] from {1} to {2}", UtilsDateTime.Current.Now().ToFormat(), TransactionInfo.Cancelled, true));
            TransactionInfo.Cancelled = true;
        }

        public void Dispose()
        {
            TransactionInfo.Infos.Add(string.Format("[{0}]: Invoke Dispose() and process transaction with [Cancelled: {1}]", UtilsDateTime.Current.Now().ToFormat(), TransactionInfo.Cancelled));
            Debug.WriteLine(TransactionInfo);
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

    #endregion
}