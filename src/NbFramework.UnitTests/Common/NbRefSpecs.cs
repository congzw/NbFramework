using Microsoft.VisualStudio.TestTools.UnitTesting;
using NbFramework.DataStandards.Core.DicTypes;
using NbFramework.DataStandards.Core.Inits;
using NbFramework.DataStandards.Dics;
using Newtonsoft.Json;

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
        [NbRefField("A1Desc", "{'Code':'OrgType','Name':'组织类型','InUse':true,'CanEdit':true}")]
        public const string A1 = "A1";
        [NbRefField("XDesc", "SomeValues")]
        public const string B1 = "X";
        [NbRefField("A2Desc", "SomeValues")]
        public const string A2 = "A2";
    }
}
