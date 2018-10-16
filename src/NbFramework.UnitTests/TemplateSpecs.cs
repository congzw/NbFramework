using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework
{
    [TestClass]
    public class TemplateSpecs
    {
        [TestMethod]
        public void If_Then_Result()
        {
            "Tempalte".ShouldEqual("Tempalte");
        }
    }
}
