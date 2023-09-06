using JiuLing.CommonLibs.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.Security
{
    [TestClass()]
    public class Base64UtilsTests
    {
        [TestMethod()]
        [DataRow("test", "dGVzdA==")]
        [DataRow("test one", "dGVzdCBvbmU=")]
        [DataRow("测试内容", "5rWL6K+V5YaF5a65")]
        public void StringToBase64Test(string input, string base64)
        {
            Assert.IsTrue(Base64Utils.StringToBase64(input) == base64);
        }

        [TestMethod()]
        [DataRow("dGVzdA==", "test")]
        [DataRow("dGVzdCBvbmU=", "test one")]
        [DataRow("5rWL6K+V5YaF5a65", "测试内容")]
        public void Base64ToStringTest(string input, string base64)
        {
            Assert.IsTrue(Base64Utils.Base64ToString(input) == base64);
        }
    }
}