using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework.WebApis.Selectors.CategorySelectors
{
    [TestClass]
    public class CategoryHttpControllerSelectorServiceSpec
    {
        [TestMethod]
        public void Select_NullArgs_Controllers_ShouldThrowEx()
        {
            var myApiControllerSelector = new CategoryHttpControllerSelectorService();
            var controllers = new List<string>();
            controllers.Add("Foo.Bar.Blah.MockController");

            myApiControllerSelector.ShouldThrowEx(null, "v2", "abC", "DeMo");
        }

        [TestMethod]
        public void Select_NullArgs_ControllerName_ShouldThrowEx()
        {
            var myApiControllerSelector = new CategoryHttpControllerSelectorService();
            var controllers = new List<string>();
            controllers.Add("Foo.Bar.Blah.MockController");

            myApiControllerSelector.ShouldThrowEx(controllers, "v2", "abC", null);
        }


        [TestMethod]
        public void Select_NoDuplicateControllerName_Should_Return_TheOne()
        {
            var myApiControllerSelector = new CategoryHttpControllerSelectorService();
            var controllers = new List<string>();
            controllers.Add("DemoSite.Domains.Mocks.Api.DemoController");
            controllers.Add("DemoSite.Domains.Mocks.Api.FooController");
            controllers.Add("DemoSite.Domains.Mocks.Api.BarController");

            myApiControllerSelector.ShouldReturnTheOne("DemoSite.Domains.Mocks.Api.DemoController", controllers, "", "", "Demo");
            myApiControllerSelector.ShouldReturnTheOne("DemoSite.Domains.Mocks.Api.FooController", controllers, "", "", "Foo");
            myApiControllerSelector.ShouldReturnTheOne("DemoSite.Domains.Mocks.Api.BarController", controllers, "", "", "Bar");
        }

        [TestMethod]
        public void Select_DifferentCategory_Should_Return_TheOne()
        {
            var myApiControllerSelector = new CategoryHttpControllerSelectorService();
            var controllers = new List<string>();
            controllers.Add("DemoSite.Domains.Mocks.Api.A1.FooController");
            controllers.Add("DemoSite.Domains.Mocks.Api.A2.FooController");

            myApiControllerSelector.ShouldReturnTheOne("DemoSite.Domains.Mocks.Api.A1.FooController", controllers, "", "A1", "Foo");
            myApiControllerSelector.ShouldReturnTheOne("DemoSite.Domains.Mocks.Api.A2.FooController", controllers, "", "A2", "Foo");
        }

        [TestMethod]
        public void Select_NestedCategory_Should_Return_TheOne()
        {
            var myApiControllerSelector = new CategoryHttpControllerSelectorService();
            var controllers = new List<string>();
            controllers.Add("DemoSite.Domains.Mocks.Api.FooController");
            controllers.Add("DemoSite.Domains.Mocks.Api.A1.FooController");
            controllers.Add("DemoSite.Domains.Mocks.Api.A1.B1.FooController");

            myApiControllerSelector.ShouldReturnTheOne("DemoSite.Domains.Mocks.Api.FooController", controllers, "", "", "Foo");
            myApiControllerSelector.ShouldReturnTheOne("DemoSite.Domains.Mocks.Api.A1.FooController", controllers, "", "A1", "Foo");
            myApiControllerSelector.ShouldReturnTheOne("DemoSite.Domains.Mocks.Api.A1.B1.FooController", controllers, "", "A1.B1", "Foo");
        }
    }

    public static class CategoryRpcControllerSelectorExtensions
    {
        public static void ShouldReturnTheOne(this ICategoryHttpControllerSelectorService selectorService, string expectedResult, IList<string> apiControllerFullNames, string version, string categories, string controller)
        {
            var theOne = selectorService.Select(apiControllerFullNames, version, categories, controller);
            theOne.ShouldEqual(expectedResult);
        }

        public static void ShouldThrowEx(this ICategoryHttpControllerSelectorService selectorService, IList<string> apiControllerFullNames, string version, string categories, string controller)
        {
            AssertHelper.ShouldThrows<ArgumentNullException>(() =>
            {
                selectorService.Select(apiControllerFullNames, version, categories, controller);
            });
        }
    }
}
