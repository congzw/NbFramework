using System;
using System.Collections.Generic;

namespace NbFramework.Common.Web.CDN
{
    /// <summary>
    /// CDN的服务器接口
    /// </summary>
    public interface ICdnServer
    {
        /// <summary>
        /// 是否启用CDNServer
        /// </summary>
        bool Enabled();

        /// <summary>
        /// CDN的服务器地址
        /// </summary>
        string BaseUri { get; set; }

        /// <summary>
        /// 默认启用CDN的文件夹（默认Content）
        /// </summary>
        List<string> CdnFolders { get; set; }
        
        /// <summary>
        /// 映射CDN的路径（如果CDN配置并处理，返回true和CND的路径）
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <param name="virtualPathForCdn"></param>
        /// <returns></returns>
        bool TryResolveCDNPath(string virtualPath, out string virtualPathForCdn);
    }

    /// <summary>
    /// CDN的服务器接口实现（默认单例）
    /// </summary>
    public class CdnServer : ICdnServer
    {
        public static string Config_Common_CdnServer = "Config.Common.CdnServer";

        public CdnServer()
        {
            CdnFolders = new List<string>();
            CdnFolders.Add("Content/libs");
            CdnFolders.Add("Content/bundles");
            BaseUri = MyConfigHelper.Resolve().GetAppSettingValue(Config_Common_CdnServer, string.Empty);
        }


        /// <summary>
        /// 是否启用CDNServer
        /// </summary>
        public bool Enabled()
        {
            return !string.IsNullOrWhiteSpace(BaseUri);
        }

        /// <summary>
        /// CDN的服务器地址
        /// </summary>
        public string BaseUri { get; set; }

        /// <summary>
        /// 默认启用CDN的文件夹（默认Content）
        /// </summary>
        public List<string> CdnFolders { get; set; }

        public bool TryResolveCDNPath(string virtualPath, out string virtualPathForCdn)
        {
            virtualPathForCdn = virtualPath;
            if (!Enabled())
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(virtualPath))
            {
                throw new ArgumentNullException("virtualPath");
            }

            foreach (var cdnFolder in CdnFolders)
            {
                if (IsStartWithCdnFolder(virtualPath, cdnFolder))
                {
                    virtualPathForCdn = FixWithCdnFolder(virtualPath, cdnFolder, BaseUri);
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// 当前的实例
        /// </summary>
        public static ICdnServer Current
        {
            get { return defaultFactoryFunc.Invoke(); }
        }

        /// <summary>
        /// 重新设置工厂方法
        /// </summary>
        /// <param name="func"></param>
        public static void SetFactoryFunc(Func<ICdnServer> func)
        {
            if (func != null)
            {
                defaultFactoryFunc = func;
            }
        }

        private static Func<ICdnServer> defaultFactoryFunc = () => defaultInstance.Value;

        private static Lazy<ICdnServer> defaultInstance = new Lazy<ICdnServer>(() => new CdnServer());

        private static bool IsStartWithCdnFolder(string virtualPath, string folder)
        {
            return virtualPath.StartsWith("~/" + folder, StringComparison.OrdinalIgnoreCase) ||
                   virtualPath.StartsWith("/" + folder, StringComparison.OrdinalIgnoreCase);
        }

        private static string FixWithCdnFolder(string virtualPath, string folder, string cdnServer)
        {
            //暂时不需要folder
            var virtualPathFix = string.Format("{0}/{1}", cdnServer.TrimEnd('/'),
                virtualPath.TrimStart('~').TrimStart('/'));
            return virtualPathFix;
        }
    }
}