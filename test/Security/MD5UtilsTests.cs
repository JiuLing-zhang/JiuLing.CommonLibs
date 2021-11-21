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
    public class MD5UtilsTests
    {
        [TestMethod()]
        [DataRow("test", "098f6bcd4621d373cade4e832627b4f6")]
        public void GetLowerValueTest(string input, string md5)
        {
            Assert.IsTrue(MD5Utils.GetLowerValue(input) == md5);
        }

        [TestMethod()]
        [DataRow("test", "098F6BCD4621D373CADE4E832627B4F6")]
        public void GetUpperValueTest(string input, string md5)
        {
            Assert.IsTrue(MD5Utils.GetUpperValue(input) == md5);
        }
    }
}