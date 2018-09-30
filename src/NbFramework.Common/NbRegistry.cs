using System;
using System.Collections.Generic;

namespace NbFramework.Common
{

    public abstract class NbRegistry<T> where T : NbRegistry<T>
    {
        private bool _inited;
        /// <summary>
        /// 从服务中初始化（通常是声明元信息的服务）
        /// </summary>
        /// <param name="nbRegistryServices"></param>
        /// <returns></returns>
        public void Init(IList<INbRegistryService<T>> nbRegistryServices)
        {
            if (_inited)
            {
                throw new InvalidOperationException("NbRegistry should't be inited more then once!");
            }
            foreach (var dicRegistryService in nbRegistryServices)
            {
                dicRegistryService.Register((T)this);
            }
            _inited = true;
        }

        /// <summary>
        /// 单例
        /// </summary>
        /// <returns></returns>
        public static T Instance
        {

            get
            {
                return AutoResolveAsSingletonHelper<T>.Lazy.Value;
            }
        }
    }

    /// <summary>
    /// 注册服务接口，实现此接口的服务必须具有无参构造函数，供注册表实例进行发现和执行
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INbRegistryService<in T> where T : NbRegistry<T>
    {
        /// <summary>
        /// 注册自定义信息
        /// </summary>
        /// <param name="nbRegistry"></param>
        void Register(T nbRegistry);
    }
}
