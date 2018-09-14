using System.Collections.Generic;

namespace NbFramework.UI.Navigations.Api
{
    public interface INavItemTreeApi
    {
        NavItemTree Get(string position);
        IList<NavItemTree> GetList(string positions);
    }
}
