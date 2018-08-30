using System;
using System.Collections.Generic;
using System.Configuration;

namespace NbFramework.Common
{
    //类库内部使用的日志组件
    /// <summary>
    /// 类库内部使用的日志组件
    /// （不依赖Log4Net，默认System.Diagnostics.Trace，支持运行时替换）
    /// </summary>
    public class UtilsLogger
    {
        public const string Config_Common_LogPrefix = "Config.Common.LogPrefix";

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="messages"></param>
        public static void LogMessage(params string[] messages)
        {
            foreach (var message in messages)
            {
                defaultLogAction.Invoke(message);
            }
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        public static void LogMessage(Type type, params string[] messages)
        {
            foreach (var message in messages)
            {

                defaultLogAction.Invoke(string.Format("[{0}] {1}", type.Name, message));
            }
        }

        /// <summary>
        /// 重新设置日志打印方式
        /// </summary>
        /// <param name="action"></param>
        public static void SetLogFunc(Action<string> action)
        {
            if (action != null)
            {
                defaultLogAction = action;
            }
        }

        private static Action<string> defaultLogAction = new Action<string>(TraceMessage);
        private static string prefix = null;
        private static void TraceMessage(string message)
        {
            if (prefix == null)
            {
                prefix = GetPrefix();
            }
            System.Diagnostics.Trace.WriteLine(prefix + message);
        }
        private static string GetPrefix()
        {
            //如果后台有设置，以config的设置为准
            string prefixSeed = "[NbFramework][UtilsLogger]";
            string preFix = ConfigurationManager.AppSettings[Config_Common_LogPrefix];
            if (!string.IsNullOrWhiteSpace(preFix))
            {
                prefixSeed = prefixSeed.Replace("NbFramework", preFix);
                prefixSeed = string.Format("[{0}]", prefixSeed).Replace("[[", "[").Replace("]]", "]");
            }
            return prefixSeed + " => ";
        }
    }
}
