using System.Collections.Generic;

namespace NbFramework.UI.Navigations
{
    public interface INavItemProcessService
    {
        int Order { get; set; }
        IList<NavItem> Process(IList<NavItem> navItems);
    }
}