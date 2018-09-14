using System.Collections.Generic;
using System.Linq;
using NbFramework.Common.Extensions;

namespace NbFramework.UI.Navigations.Api._Impl
{
    //demo: impl with webapi & proxy mode?
    public class NavItemTreeApi : INavItemTreeApi
    {
        private readonly INavItemRepository _navItemRepository;
        private readonly IList<INavItemFilter> _navItemFilters;

        public NavItemTreeApi(INavItemRepository navItemRepository, IList<INavItemFilter> navItemFilters)
        {
            _navItemRepository = navItemRepository;
            _navItemFilters = navItemFilters;
        }

        public NavItemTree Get(string position)
        {
            var navItems = GetNavItems(position);
            return NavItemTree.ConvertTrees(navItems).FirstOrDefault();
        }

        public IList<NavItemTree> GetList(string positions)
        {
            //todo
            throw new System.NotImplementedException();
        }

        private IList<NavItem> GetNavItems(string position)
        {
            var navItems = _navItemRepository.GetAll();
            if (!position.IsNullOrWhiteSpace())
            {
                navItems = _navItemRepository.GetAll().Where(x =>  position.NbEquals(x.Position)).ToList();
            }

            if (_navItemFilters.IsNullOrEmpty())
            {
                return navItems;
            }

            foreach (var processer in _navItemFilters.OrderBy(x => x.Order))
            {
                navItems = processer.Process(navItems);
            }
            return navItems;
        }
    }
}