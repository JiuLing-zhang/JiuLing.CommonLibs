using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiuLing.CommonLibs.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuLing.CommonLibs.Security.Tests
{
    [TestClass()]
    public class Base64UtilsTests
    {
        [TestMethod()]
        [DataRow("test", "dGVzdA==")]
        [DataRow("test one", "dGVzdCBvbmU=")]
        public void GetStringValueTest(string input, string base64)
        {
            Assert.IsTrue(Base64Utils.GetStringValue(input) == base64);
        }

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