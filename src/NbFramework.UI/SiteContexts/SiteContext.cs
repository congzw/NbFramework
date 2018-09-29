namespace NbFramework.UI.SiteContexts
{
    /// <summary>
    /// 站点的上下文
    /// </summary>
    public class SiteContext
    {

        /// <summary>
        /// 站点信息
        /// </summary>
        public SiteInfo SiteInfo { get; set; }

        private static SiteContext _current;
        /// <summary>
        /// 站点的上下文
        /// </summary>
        public static SiteContext Current
        {
            get { return _current ?? (_current = GetCurrent()); }
            set { _current = value; }
        }

        private static SiteContext GetCurrent()
        {
            //todo
            var siteContext = new SiteContext
            {
                SiteInfo = new SiteInfo()
                {
                    HomeUrl = "~/",
                    LogoUrl = "~/Content/Images/demo.jpg",
                    DisplayName = "默认站点",
                    Gray = false
                }
            };

            return siteContext;
        }
    }
}