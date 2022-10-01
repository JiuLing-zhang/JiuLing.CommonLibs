using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiuLing.CommonLibs.Security;
using System;
using System.Collections.Generic;
using System.IO;
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
        public void GetStringValueToLowerTest(string input, string md5)
        {
            Assert.IsTrue(MD5Utils.GetStringValueToLower(input) == md5);
        }

        [TestMethod()]
        [DataRow("test", "098F6BCD4621D373CADE4E832627B4F6")]
        public void GetStringValueToUpperTest(string input, string md5)
        {
            Assert.IsTrue(MD5Utils.GetStringValueToUpper(input) == md5);
        }

        [TestMethod()]
        public void GetFileValueToLowerTest()
        {
            string md5 = "3de8f8b0dc94b8c2230fab9ec0ba0506";
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            Assert.IsTrue(MD5Utils.GetFileValueToLower(fileName) == md5);
        }

        [TestMethod()]
        public void GetFileValueToUpperTest()
        {
            string md5 = "3de8f8b0dc94b8c2230fab9ec0ba0506".ToUpper();
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            Assert.IsTrue(MD5Utils.GetFileValueToUpper(fileName) == md5);
        }

        [TestMethod()]
        public void GetFileValueToLowerStreamTest()
        {
            string md5 = "3de8f8b0dc94b8c2230fab9ec0ba0506";
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            using var stream = File.OpenRead(fileName);
            Assert.IsTrue(MD5Utils.GetFileValueToLower(stream) == md5);
        }

        [TestMethod()]
        public void GetFileValueToUpperStreamTest()
        {
            string md5 = "3de8f8b0dc94b8c2230fab9ec0ba0506".ToUpper();
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            using var stream = File.OpenRead(fileName);
            Assert.IsTrue(MD5Utils.GetFileValueToUpper(stream) == md5);
        }
    }
}