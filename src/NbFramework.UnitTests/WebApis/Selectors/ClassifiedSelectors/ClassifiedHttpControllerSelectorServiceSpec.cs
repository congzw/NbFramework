using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework.WebApis.Selectors.ClassifiedSelectors
{
    [TestClass]
    public class ClassifiedHttpControllerSelectorServiceSpec
    {
        [TestMethod]
        public void Select_NullArgs_ShouldThrowEx()
        {
            var myApiControllerSelector = new ClassifiedHttpControllerSelectorService();
            var controllers = new List<string>();
            controllers.Add("Xxx.Web.Api.MockController");

            myApiControllerSelector.ShouldThrowEx(null, "Api", "ABC", null, null);
            myApiControllerSelector.ShouldThrowEx(controllers, null, "ABC", null, null);
            myApiControllerSelector.ShouldThrowEx(controllers, "Api", null, null, null);
        }

        [TestMethod]
        public void Select_NoArea_Should_Return_TheOne()
        {
            var myApiControllerSelector = new ClassifiedHttpControllerSelectorService();
            var controllers = new List<string>();
            controllers.Add("Xxx.Web.Api.MockController");
            controllers.Add("Xxx.Web.Api.A.MockController");
            controllers.Add("Xxx.Web.Api.A.B.MockController");
            controllers.Add("Xxx.Web.Api.A.B.A.MockController");

            myApiControllerSelector.ShouldReturnTheOne("Xxx.Web.Api.MockController", controllers, "Api", "Mock", null, null);
            myApiControllerSelector.ShouldReturnTheOne("Xxx.Web.Api.A.MockController", controllers, "Api", "Mock", null, "A");
            myApiControllerSelector.ShouldReturnTheOne("Xxx.Web.Api.A.B.MockController", controllers, "Api", "Mock", null, "A", "B");
            myApiControllerSelector.ShouldReturnTheOne("Xxx.Web.Api.A.B.A.MockController", controllers, "Api", "Mock", null, "A", "B", "A");
        }

        [TestMethod]
        public void Select_WihtArea_Should_Return_TheOne()
        {
            var myApiControllerSelector = new ClassifiedHttpControllerSelectorService();
            var controllers = new List<string>();
            controllers.Add("Xxx.Web.Api.MockController");
            controllers.Add("Xxx.Web.Api.A.MockController");
            controllers.Add("Xxx.Web.Api.A.B.MockController");
            controllers.Add("Xxx.Web.Api.A.B.A.MockController");
            controllers.Add("Xxx.Web.Areas.AREA.Api.MockController");
            controllers.Add("Xxx.Web.Areas.AREA.Api.A.MockController");
            controllers.Add("Xxx.Web.Areas.AREA.Api.A.B.MockController");
            controllers.Add("Xxx.Web.Areas.AREA.Api.A.B.A.MockController");

            myApiControllerSelector.ShouldReturnTheOne("Xxx.Web.Api.MockController", controllers, "Api", "Mock", null, null);
            myApiControllerSelector.ShouldReturnTheOne("Xxx.Web.Api.A.MockController", controllers, "Api", "Mock", null, "A");
            myApiControllerSelector.ShouldReturnTheOne("Xxx.Web.Api.A.B.MockController", controllers, "Api", "Mock", null, "A", "B");
            myApiControllerSelector.ShouldReturnTheOne("Xxx.Web.Api.A.B.A.MockController", controllers, "Api", "Mock", null, "A", "B", "A");


            myApiControllerSelector.ShouldReturnTheOne("Xxx.Web.Areas.AREA.Api.MockController", controllers, "Api", "Mock", "AREA", null);
            myApiControllerSelector.ShouldReturnTheOne("Xxx.Web.Areas.AREA.Api.A.MockController", controllers, "Api", "Mock", "AREA", "A");
            myApiControllerSelector.ShouldReturnTheOne("Xxx.Web.Areas.AREA.Api.A.B.MockController", controllers, "Api", "Mock", "AREA", "A", "B");
            myApiControllerSelector.ShouldReturnTheOne("Xxx.Web.Areas.AREA.Api.A.B.A.MockController", controllers, "Api", "Mock", "AREA", "A", "B", "A");
        }

        [TestMethod]
        public void Select_SamePrefix_Should_Return_TheOne()
        {
            var myApiControllerSelector = new ClassifiedHttpControllerSelectorService();
            var controllers = new List<string>();
            controllers.Add("Foo.Web.Areas.Live.Api.ActivityController");
            controllers.Add("Foo.Web.Areas.Live.Api.ActivityInfoController");

            myApiControllerSelector.ShouldReturnTheOne("Foo.Web.Areas.Live.Api.ActivityController", controllers, "Api", "Activity", "Live", null);
            myApiControllerSelector.ShouldReturnTheOne("Foo.Web.Areas.Live.Api.ActivityInfoController", controllers, "Api", "ActivityInfo", "Live", null);
        }
    }

    public static class NamespaceApiControllerSelectorExtensions
    {
        public static void ShouldReturnTheOne(this IClassifiedHttpControllerSelectorService selectorService, string expectedResult, IList<string> apiControllerFullNames, string apiFolder, string controller, string area, params string[] categories)
        {
            var theOne = selectorService.Select(apiControllerFullNames, apiFolder, controller, area, categories);
            theOne.ShouldEqual(expectedResult);
        }

        public static void ShouldThrowEx(this IClassifiedHttpControllerSelectorService selectorService, IList<string> apiControllerFullNames, string apiFolder, string controller, string area, params string[] categories)
        {
            AssertHelper.ShouldThrows<ArgumentNullException>(() =>
            {
                selectorService.Select(apiControllerFullNames, apiFolder, controller, area, categories);
            });

            AssertHelper.ShouldThrows<ArgumentNullException>(() =>
            {
                selectorService.Select(apiControllerFullNames, apiFolder, controller, area, categories);
            });

            AssertHelper.ShouldThrows<ArgumentNullException>(() =>
            {
                selectorService.Select(apiControllerFullNames, apiFolder, controller, area, categories);
            }); ;
        }
    }
}
