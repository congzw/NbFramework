using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework.DataStandards.Dics.Grades
{
    [TestClass]
    public class GradeMetaProviderSpecs
    {
        [TestMethod]
        public void Create_should_ok()
        {
            var metaProvider = new GradeMetaProvider();
            var dicMeta = metaProvider.Create();
            dicMeta.ShouldNotNull();
            dicMeta.LogJson();
        }
    }
}
