namespace NbFramework.UI.SiteContexts
{
    /// <summary>
    /// 站点信息
    /// </summary>
    public class SiteInfo
    {
        /// <summary>
        /// 首页链接
        /// </summary>
        public string HomeUrl { get; set; }

        /// <summary>
        /// Logo的Url
        /// </summary>
        public string LogoUrl { get; set; }
        /// <summary>
        /// 站点的名称（显示）
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 全站置灰
        /// </summary>
        public bool Gray { get; set; }
    }
}
