using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace JiuLing.CommonLibs.Security.Tests
{
    [TestClass()]
    public class SHA1UtilsTests
    {
        [TestMethod()]
        public void GetFileValueToLowerTest()
        {
            string md5 = "26d82f1931cbdbd83c2a6871b2cecd5cbcc8c26b";
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            Assert.IsTrue(SHA1Utils.GetFileValueToLower(fileName) == md5);
        }

        [TestMethod()]
        public void GetFileValueToUpperTest()
        {
            string md5 = "26d82f1931cbdbd83c2a6871b2cecd5cbcc8c26b".ToUpper();
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            Assert.IsTrue(SHA1Utils.GetFileValueToUpper(fileName) == md5);
        }

        [TestMethod()]
        public void GetFileValueToLowerStreamTest()
        {
            string md5 = "26d82f1931cbdbd83c2a6871b2cecd5cbcc8c26b";
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            using var stream = File.OpenRead(fileName);
            Assert.IsTrue(SHA1Utils.GetFileValueToLower(stream) == md5);
        }

        [TestMethod()]
        public void GetFileValueToUpperStreamTest()
        {
            string md5 = "26d82f1931cbdbd83c2a6871b2cecd5cbcc8c26b".ToUpper();
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            using var stream = File.OpenRead(fileName);
            Assert.IsTrue(SHA1Utils.GetFileValueToUpper(stream) == md5);
        }

        [TestMethod()]
        [DataRow("test", "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3")]
        public void GetStringValueToLowerTest(string input, string result)
        {
            Assert.IsTrue(SHA1Utils.GetStringValueToLower(input) == result);
        }

        [TestMethod()]
        [DataRow("test", "A94A8FE5CCB19BA61C4C0873D391E987982FBBD3")]
        public void GetStringValueToUpperTest(string input, string result)
        {
            Assert.IsTrue(SHA1Utils.GetStringValueToUpper(input) == result);
        }

    }
}