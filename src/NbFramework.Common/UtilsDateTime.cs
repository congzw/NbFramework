using System;

namespace NbFramework.Common
{
    public interface IUtilsDateTime
    {
        DateTime Now();
    }

    public class UtilsDateTime : IUtilsDateTime
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public static IUtilsDateTime Current
        {
            get
            {
                return defaultFactoryFunc.Invoke();
            }
        }

        /// <summary>
        /// 获取工厂方法
        /// </summary>
        public static Func<IUtilsDateTime> GetFactoryFunc()
        {
            return defaultFactoryFunc;
        }
        /// <summary>
        /// 重新设置工厂方法
        /// </summary>
        /// <param name="func"></param>
        public static void SetFactoryFunc(Func<IUtilsDateTime> func)
        {
            if (func != null)
            {
                defaultFactoryFunc = func;
            }
        }

        private static Func<IUtilsDateTime> defaultFactoryFunc = CreateDefault;
        private static IUtilsDateTime CreateDefault()
        {
            var defaultImpl = new UtilsDateTime();
            return defaultImpl;
        }
    }
}
