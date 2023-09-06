using JiuLing.CommonLibs.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.Log
{
    [TestClass()]
    public class LogManagerTests
    {
        [TestMethod()]
        public void GetLoggerTest()
        {
            Assert.IsTrue(LogManager.GetLogger() != null);
        }
    }
}