using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiuLing.CommonLibs.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JiuLing.CommonLibs.Security.Tests
{
    [TestClass()]
    public class SHA1UtilsTests
    {
        [TestMethod()]
        public void GetFileLowerValueTest()
        {
            string md5 = "26d82f1931cbdbd83c2a6871b2cecd5cbcc8c26b";
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            Assert.IsTrue(SHA1Utils.GetFileLowerValue(fileName) == md5);
        }

        [TestMethod()]
        public void GetFileUpperValueTest()
        {
            string md5 = "26d82f1931cbdbd83c2a6871b2cecd5cbcc8c26b".ToUpper();
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            Assert.IsTrue(SHA1Utils.GetFileUpperValue(fileName) == md5);
        }

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
    }
}