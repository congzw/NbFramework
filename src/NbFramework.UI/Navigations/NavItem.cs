using System;

namespace NbFramework.UI.Navigations
{
    /// <summary>
    /// 导航项
    /// </summary>
    public class NavItem
    {
        public NavItem()
        {
            NavItemTypes = (NavItemType.Breadcrumb | NavItemType.Menu).ToTypeNames();
        }

        public string Pk { get; set; }
        public string ParentPk { get; set; }
        public string Text { get; set; }
        public string Href { get; set; }
        public string Class { get; set; }
        public float SortNum { get; set; }
        public string FromModule { get; set; }
        public string Position { get; set; }
        public string NavItemTypes { get; set; }
    }
}