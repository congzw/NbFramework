using System.Collections.Generic;

namespace NbFramework.UI.Navigations
{
    public interface INavItemRepository
    {
        IList<NavItem> GetAll();
    }
}
