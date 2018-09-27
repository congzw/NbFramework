namespace NbFramework.UI.SiteConfigs
{
    public class SiteConfigContext
    {
        public bool SiteGreyEnabled { get; set; }

        static SiteConfigContext()
        {
            Current = new SiteConfigContext();
        }

        /// <summary>
        /// 获取当前上下文
        /// todo get from config
        /// </summary>
        public static SiteConfigContext Current { get; set; }
    }
}
