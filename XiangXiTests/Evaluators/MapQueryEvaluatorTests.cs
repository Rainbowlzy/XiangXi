using Microsoft.VisualStudio.TestTools.UnitTesting;
using XiangXi.Evaluators;

namespace XiangXiTests.Evaluators
{
    [TestClass()]
    public class MapQueryEvaluatorTests
    {
        [TestMethod()]
        public void QueryListTest()
        {
            var queryList = MapQueryEvaluator.QueryList("人口");
            Assert.AreEqual("", queryList.ToJson());
            Assert.Fail();
        }
    }
}