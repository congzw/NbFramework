using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework.Common
{
    [TestClass]
    public class NbRefSpecs
    {
        [TestMethod]
        public void GetAllNbRefFieldStrings_should_ok()
        {
            var allNbRefFieldStrings = NbRefFieldValue.GetAllNbRefFieldStrings(typeof(MockCodes));
            allNbRefFieldStrings.LogJson();
            ShouldOK("A1", "A1", "A1Desc", allNbRefFieldStrings[0]);
            ShouldOK("X", "B1", "XDesc", allNbRefFieldStrings[1]);
            ShouldOK("A2", "A2", "A2Desc", allNbRefFieldStrings[2]);
        }

        private static void ShouldOK(string code, string name, string desc, NbRefFieldValue value)
        {
            value.FieldValue.ShouldEqual(code);
            value.FieldName.ShouldEqual(name);
            value.Description.ShouldEqual(desc);
            AssertHelper.WriteLine("----");
        }
    }
    public static class MockCodes
    {
        [NbRefField("A1Desc")]
        public const string A1 = "A1";
        [NbRefField("XDesc")]
        public const string B1 = "X";
        [NbRefField("A2Desc")]
        public const string A2 = "A2";
    }
}
