using System.Collections.Generic;
using System.Linq;
using JiuLing.CommonLibs.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.Text
{
    [TestClass()]
    public class StartupCommandUtilsTests
    {
        [TestMethod()]
        [Ignore("初始化方法，不测试")]
        public void InitializeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("-a test1 test2 test3 -b", @"-a", true)]
        [DataRow("-a test1 test2 test3 -b", @"-b", true)]
        [DataRow("-a test1 test2 test3 -b", @"-c", false)]
        public void HasCommandTest(string input, string key, bool result)
        {
            StartupCommandUtils.Initialize(input);
            Assert.IsTrue(StartupCommandUtils.HasCommand(key) == result);
        }

        [TestMethod()]
        public void GetCommandValueTest()
        {
            string input = "-a test1 test2 test3 -b -c test-c";
            string key;
            IList<string> testResult;
            IList<string> result;
            StartupCommandUtils.Initialize(input);

            key = "-a";
            testResult = new List<string>() { "test1", "test2", "test3" };
            result = StartupCommandUtils.GetCommandValue(key);
            Assert.IsTrue(result.All(testResult.Contains) && result.Count == testResult.Count);

            key = "-b";
            testResult = new List<string>();
            result = StartupCommandUtils.GetCommandValue(key);
            Assert.IsTrue(result.All(testResult.Contains) && result.Count == testResult.Count);

            key = "-c";
            testResult = new List<string>() { "test-c" };
            result = StartupCommandUtils.GetCommandValue(key);
            Assert.IsTrue(result.All(testResult.Contains) && result.Count == testResult.Count);

            key = "-d";
            result = StartupCommandUtils.GetCommandValue(key);
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void TryGetCommandValueTest()
        {
            string input = "-a test1 test2 test3 -b -c test-c";
            string key;
            IList<string> testResult;
            IList<string> outResult;
            bool result;
            StartupCommandUtils.Initialize(input);

            key = "-a";
            testResult = new List<string>() { "test1", "test2", "test3" };
            result = StartupCommandUtils.TryGetCommandValue(key, out outResult);
            Assert.IsTrue(result);
            Assert.IsTrue(outResult.All(testResult.Contains) && outResult.Count == testResult.Count);

            key = "-b";
            testResult = new List<string>();
            result = StartupCommandUtils.TryGetCommandValue(key, out outResult);
            Assert.IsTrue(result);
            Assert.IsTrue(outResult.All(testResult.Contains) && outResult.Count == testResult.Count);

            key = "-c";
            testResult = new List<string>() { "test-c" };
            result = StartupCommandUtils.TryGetCommandValue(key, out outResult);
            Assert.IsTrue(result);
            Assert.IsTrue(outResult.All(testResult.Contains) && outResult.Count == testResult.Count);

            key = "-d";
            result = StartupCommandUtils.TryGetCommandValue(key, out outResult);
            Assert.IsFalse(result);
            Assert.IsNull(outResult);

        }
    }
}