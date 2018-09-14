using System.Collections.Generic;

namespace NbFramework.UI.Navigations
{
    public interface INavItemService
    {
        IList<NavItem> GetNavItems(GetNavItemsArgs args);
    }

    public class GetNavItemsArgs
    {
        public string Position { get; set; }
    }
}