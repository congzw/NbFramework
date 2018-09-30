using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework.DataStandards.Dics.Phases
{
    [TestClass]
    public class PhaseMetaProviderSpecs
    {
        [TestMethod]
        public void Create_should_ok()
        {
            var metaProvider = new PhaseMetaProvider();
            var dicMeta = metaProvider.Create();
            dicMeta.ShouldNotNull();
            dicMeta.LogJson();
        }
    }
}
