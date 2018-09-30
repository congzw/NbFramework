using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework.DataStandards.Dics.Subjects
{
    [TestClass]
    public class SubjectMetaProviderSpecs
    {
        [TestMethod]
        public void Create_should_ok()
        {
            var metaProvider = new SubjectMetaProvider();
            var dicMeta = metaProvider.Create();
            dicMeta.ShouldNotNull();
            dicMeta.LogJson();
        }
    }
}
