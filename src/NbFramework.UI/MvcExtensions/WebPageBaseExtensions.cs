using System;
using System.Text;
using System.Web.WebPages;

namespace NbFramework.UI.MvcExtensions
{
    public class AngularAppModule
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public bool IsDefaultMainApp()
        {
            return GetDefaultMainApp().Equals(Name, StringComparison.OrdinalIgnoreCase);
        }
        public string GetDefaultMainApp()
        {
            return "mainApp";
        }
    }

    public static class WebPageBaseExtensions
    {
        public static void SetValueFor<T>(this WebPageBase webPageBase, string name, T value)
        {
            var nameKey = name.ToLower();
            webPageBase.Context.Items[nameKey] = value;
        }

        public static T GetValueFor<T>(this WebPageBase webPageBase, string name, T defaultValue)
        {
            var nameKey = name.ToLower();
            if (webPageBase.Context.Items[nameKey] == null)
            {
                return defaultValue;
            }
            var result = (T)webPageBase.Context.Items[nameKey];
            return result;
        }

        /// <summary>
        /// 截取汉字
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public static string Truncate(this string value, int count, string append = "")
        {

            if (value == null) return string.Empty;

            var len = count * 2;
            int aequilateLength = 0, cutLength = 0;
            var encoding = Encoding.GetEncoding("gb2312");

            var cutStr = value;
            var strLength = cutStr.Length;
            byte[] bytes;
            for (int i = 0; i < strLength; i++)
            {
                bytes = encoding.GetBytes(cutStr.Substring(i, 1));
                if (bytes.Length >= 2)//不是英文
                    aequilateLength += 2;
                else
                    aequilateLength++;

                if (aequilateLength <= len) cutLength += 1;

                if (aequilateLength > len)
                    return cutStr.Substring(0, cutLength) + append;
            }
            return cutStr;
        }

        #region for angular

        public static void SetAngularSupport(this WebPageBase webPageBase, bool value)
        {
            webPageBase.SetValueFor("AngularSupport", value);
        }

        public static bool GetAngularSupport(this WebPageBase webPageBase)
        {
            return webPageBase.GetValueFor("AngularSupport", true);
        }
        
        //public static void SetAngularAppModule(this WebPageBase webPageBase, string value)
        //{
        //    webPageBase.SetValueFor("AngularAppModule", value);
        //}

        //public static string GetAngularAppModule(this WebPageBase webPageBase)
        //{
        //    return webPageBase.GetValueFor("AngularAppModule", "mainApp");
        //}

        public static void SetAngularAppModule(this WebPageBase webPageBase, AngularAppModule value)
        {
            webPageBase.SetValueFor("AngularAppModule", value);
        }

        private static readonly AngularAppModule _defaultAngularAppModule = new AngularAppModule() { Name = "mainApp", Path = "~/Content/scripts/mainApp.js" };
        public static AngularAppModule GetAngularAppModule(this WebPageBase webPageBase)
        {
            return webPageBase.GetValueFor("AngularAppModule", _defaultAngularAppModule);
        }


        #endregion

        #region for debug

        public static void SetDebugMode(this WebPageBase webPageBase, bool value)
        {
            webPageBase.SetValueFor("DebugMode", value);
        }

        public static bool GetDebugMode(this WebPageBase webPageBase)
        {
            //todo read from context
            return webPageBase.GetValueFor("DebugMode", true);
        }

        #endregion

        #region for domain

        /// <summary>
        /// 截取组织名
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public static string TruncateOrgName(this string value, int count = 10, string append = "...")
        {
            return Truncate(value, count, append);
        }

        #endregion
    }
}