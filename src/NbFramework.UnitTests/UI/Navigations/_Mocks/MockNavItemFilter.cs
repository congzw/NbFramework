using System.Collections.Generic;
using System.Linq;
using NbFramework.Common.Extensions;

namespace NbFramework.UI.Navigations._Mocks
{
    public class MockNavItemFilter : INavItemFilter
    {
        public int Order { get; set; }
        public IList<NavItem> Process(IList<NavItem> navItems)
        {
            var item = navItems.FirstOrDefault(x => StringExtensions.NbEquals(x.Pk, "Root_A_1"));
            if (item != null)
            {
                item.Hidden = true;
            }
            return navItems;
        }
    }
}