using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework.DataStandards.Dics.OrgTypes
{
    [TestClass]
    public class OrgTypeMetaProviderSpecs
    {
        [TestMethod]
        public void Create_should_ok()
        {
            var metaProvider = new OrgTypeMetaProvider();
            var dicMeta = metaProvider.Create();
            dicMeta.ShouldNotNull();
            dicMeta.LogJson();
        }
    }
}
