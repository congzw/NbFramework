using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework.Common.Extensions
{
    [TestClass]
    public class StringExtensionsSpecs
    {
        [TestMethod]
        public void NbEquals_Null_Empty_should_equal()
        {
            "".NbEquals("").ShouldTrue();
            " ".NbEquals("").ShouldTrue();
            "".NbEquals(null).ShouldTrue();
            ((string)null).NbEquals("").ShouldTrue();
        }

        [TestMethod]
        public void NbEquals_AnyCase_should_equal()
        {
            "A".NbEquals("a").ShouldTrue();
            "A".NbEquals("a ").ShouldTrue();
            "A".NbEquals(" a ").ShouldTrue();
        }
    }
}
