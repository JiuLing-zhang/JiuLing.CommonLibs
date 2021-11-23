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
    public class SHA1UtilsTests
    {
        [TestMethod()]
        [DataRow("Security\\test.txt", "f2d974f36a4ea1be3d157b2129a9e0080c680c29")]
        public void GetFileLowerValueTest(string fileName, string sha1)
        {
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}{fileName}";
            Assert.IsTrue(SHA1Utils.GetFileLowerValue(path) == sha1);
        }

        [TestMethod()]
        [DataRow("Security\\test.txt", "F2D974F36A4EA1BE3D157B2129A9E0080C680C29")]
        public void GetFileUpperValueTest(string fileName, string sha1)
        {
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}{fileName}";
            Assert.IsTrue(SHA1Utils.GetFileUpperValue(path) == sha1);
        }
    }
}