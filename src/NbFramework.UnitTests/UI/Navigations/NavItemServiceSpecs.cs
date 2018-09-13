using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NbFramework.UI.Navigations._Impl;
using NbFramework.UI.Navigations._Mocks;

namespace NbFramework.UI.Navigations
{
    [TestClass]
    public class NavItemServiceSpecs
    {
        [TestMethod]
        public void GetNavItems_no_processer_should_return_all()
        {
            var memoryNavItemRepository = new MemoryNavItemRepository();
            var navItems = memoryNavItemRepository.Items;
            var navItemService = new NavItemService(memoryNavItemRepository, null);
            var items = navItemService.GetNavItems(new GetNavItemsArgs());
            items.Count(x => !x.Hidden).ShouldEqual(navItems.Count);
        }

        [TestMethod]
        public void GetNavItems_with_processer_should_return_ok()
        {
            var memoryNavItemRepository = new MemoryNavItemRepository();
            var navItems = memoryNavItemRepository.Items;
            var navItemService = new NavItemService(memoryNavItemRepository, new List<INavItemProcessService>(){new MockNavItemProcessService()});
            var items = navItemService.GetNavItems(new GetNavItemsArgs());
            items.Count(x => !x.Hidden).ShouldEqual(navItems.Count - 1);
        }
    }
}
