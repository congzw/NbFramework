using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework.UI.Navigations
{
    [TestClass]
    public class NavItemTypeSpecs
    {
        [TestMethod]
        public void HasFlag_should_ok()
        {
            (NavItemType.Menu).HasFlag(NavItemType.Menu).ShouldTrue();
            (NavItemType.Menu).HasFlag(NavItemType.Breadcrumb).ShouldFalse();

            (NavItemType.Breadcrumb | NavItemType.Menu).HasFlag(NavItemType.Breadcrumb).ShouldTrue();
            (NavItemType.Breadcrumb | NavItemType.Menu).HasFlag(NavItemType.Menu).ShouldTrue();
        }

        [TestMethod]
        public void HasType_single_bit_should_ok()
        {
            var typeNames = NavItemType.Menu.ToTypeNames();
            typeNames.HasType(NavItemType.Menu).ShouldTrue("'Menu' has 'Menu'");
            typeNames.HasType(NavItemType.Breadcrumb).ShouldFalse("'Menu' has 'Breadcrumb'");
            typeNames.HasType(NavItemType.Menu | NavItemType.Breadcrumb).ShouldFalse("'Menu' has 'Menu, Breadcrumb'");
        }

        [TestMethod]
        public void HasType_multi_bit_should_ok()
        {
            var typeNames = (NavItemType.Menu | NavItemType.Breadcrumb).ToTypeNames();
            typeNames.HasType(NavItemType.Menu).ShouldTrue("'Menu, Breadcrumb' has 'Menu'");
            typeNames.HasType(NavItemType.Breadcrumb).ShouldTrue("'Menu, Breadcrumb' has 'Breadcrumb'");
            typeNames.HasType(NavItemType.Menu | NavItemType.Breadcrumb).ShouldTrue("'Menu, Breadcrumb' has 'Menu, Breadcrumb'");
        }
    }
}
