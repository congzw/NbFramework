using System.Collections.Generic;

namespace NbFramework.UI.Navigations
{
    public interface INavItemFilter
    {
        int Order { get; set; }
        IList<NavItem> Process(IList<NavItem> navItems);
    }
}