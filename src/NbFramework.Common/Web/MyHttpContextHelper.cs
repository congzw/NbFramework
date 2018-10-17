using System;
using System.Web;

namespace NbFramework.Common.Web
{
    /// <summary>
    /// HttpContextBase
    /// </summary>
    public class MyHttpContextHelper
    {
        #region helpers

        //better for unit test
        private static Func<HttpContextBase> _getCurrentHttpContext = () => HttpContext.Current == null ? null : new HttpContextWrapper(HttpContext.Current);
        public static Func<HttpContextBase> GetCurrentHttpContext
        {
            get { return _getCurrentHttpContext; }
            set { _getCurrentHttpContext = value; }
        }

        public static MyHttpContextHelper Instance = new MyHttpContextHelper();

        #endregion

        /// <summary>
        /// 获取当前的请求
        /// </summary>
        /// <returns></returns>
        public HttpContextBase GetHttpContext()
        {
            return GetCurrentHttpContext();
        }

        /// <summary>
        /// 检测HttpContext是否可用（如果可用，返回当前url）
        /// </summary>
        /// <param name="currentUrl"></param>
        /// <returns></returns>
        public bool IsRequestAvailable(out string currentUrl)
        {
            currentUrl = "";
            var httpContextBase = GetHttpContext();
            if (httpContextBase == null)
            {
                return false;
            }

            try
            {
                //集成模式下运行
                if (httpContextBase.Request.Url != null)
                {
                    currentUrl = httpContextBase.Request.Url.PathAndQuery;
                }
                return true;
            }
            catch (HttpException ex)
            {
                var logEx = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 检测HttpContext是否可用
        /// </summary>
        /// <returns></returns>
        public bool IsRequestAvailable()
        {
            string currentUrl;
            return IsRequestAvailable(out currentUrl);
        }
        
        /// <summary>
        /// 从当前的请求参数中查找键值，没有则使用提供的默认参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetCurrentUriParams<T>(string name, T defaultValue)
        {
            object value = GetCurrentUriParams(name);
            if (value == null)
            {
                return defaultValue;
            }

            var valueString = value.ToString().Trim();
            var result = (T)Convert.ChangeType(valueString, typeof(T));
            return result;
        }

        /// <summary>
        /// 获取与 System.Collections.Specialized.NameValueCollection 中的指定键关联的值，这些值已合并为一个以逗号分隔的列表。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetCurrentUriParams(string name)
        {
            var value = GetHttpContext().Request.Params.Get(name);
            return value;
        }
    }
}
