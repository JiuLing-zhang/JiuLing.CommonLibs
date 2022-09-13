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
    }
}