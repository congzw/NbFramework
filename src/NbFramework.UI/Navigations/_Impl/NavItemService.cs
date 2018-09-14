using System.Collections.Generic;
using System.Linq;
using NbFramework.Common;
using NbFramework.Common.Extensions;

namespace NbFramework.UI.Navigations._Impl
{
    public class NavItemService : INavItemService
    {
        private readonly INavItemRepository _navItemRepository;
        private readonly IList<INavItemFilter> _navItemFilters;

        public NavItemService(INavItemRepository navItemRepository, IList<INavItemFilter> navItemFilters)
        {
            _navItemRepository = navItemRepository;
            _navItemFilters = navItemFilters;
        }

        public IList<NavItem> GetNavItems(GetNavItemsArgs args)
        {
            NbGuard.MakeSureIsNotDefault(args);
            var navItems = _navItemRepository.GetAll();
            if (!args.Position.IsNullOrWhiteSpace())
            {
                navItems = _navItemRepository.GetAll().Where(x => args.Position.NbEquals(x.Position)).ToList();
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
