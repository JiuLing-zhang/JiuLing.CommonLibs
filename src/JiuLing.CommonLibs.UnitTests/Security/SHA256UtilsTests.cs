using JiuLing.CommonLibs.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace JiuLing.CommonLibs.Security.Tests
{
    [TestClass()]
    public class SHA256UtilsTests
    {
        [TestMethod()]
        public void GetFileValueToLowerTest()
        {
            string hash = "f29bc64a9d3732b4b9035125fdb3285f5b6455778edca72414671e0ca3b2e0de";
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            Assert.IsTrue(SHA256Utils.GetFileValueToLower(fileName) == hash);
        }

        [TestMethod()]
        public void GetFileValueToUpperTest()
        {
            string hash = "F29BC64A9D3732B4B9035125FDB3285F5B6455778EDCA72414671E0CA3B2E0DE";
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            Assert.IsTrue(SHA256Utils.GetFileValueToUpper(fileName) == hash);
        }

        [TestMethod()]
        public void GetFileValueToLowerTest1()
        {
            string hash = "f29bc64a9d3732b4b9035125fdb3285f5b6455778edca72414671e0ca3b2e0de";
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            using (var stream = File.OpenRead(fileName))
            {
                Assert.IsTrue(SHA256Utils.GetFileValueToLower(stream) == hash);
            }
        }

        [TestMethod()]
        public void GetFileValueToUpperTest1()
        {
            string hash = "F29BC64A9D3732B4B9035125FDB3285F5B6455778EDCA72414671E0CA3B2E0DE";
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            using (var stream = File.OpenRead(fileName))
            {
                Assert.IsTrue(SHA256Utils.GetFileValueToUpper(stream) == hash);
            }
        }

        [TestMethod()]
        [DataRow("hello world", "b94d27b9934d3e08a52e52d7da7dabfac484efe37a5380ee9088f7ace2efcde9")]
        [DataRow("Test1", "8a863b145dc6e4ed7ac41c08f7536c476ebac7509e028ed2b49f8bd5a3562b9f")]
        public void GetStringValueToLowerTest(string input, string result)
        {
            Assert.IsTrue(SHA256Utils.GetStringValueToLower(input) == result);
        }

        [TestMethod()]
        [DataRow("hello world", "B94D27B9934D3E08A52E52D7DA7DABFAC484EFE37A5380EE9088F7ACE2EFCDE9")]
        [DataRow("Test1", "8A863B145DC6E4ED7AC41C08F7536C476EBAC7509E028ED2B49F8BD5A3562B9F")]
        public void GetStringValueToUpperTest(string input, string result)
        {
            Assert.IsTrue(SHA256Utils.GetStringValueToUpper(input) == result);
        }

        [TestMethod()]
        public void GetBytesValueToLowerTest()
        {
            string hash = "f29bc64a9d3732b4b9035125fdb3285f5b6455778edca72414671e0ca3b2e0de";
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            var bytes = File.ReadAllBytes(fileName);
            Assert.IsTrue(SHA256Utils.GetBytesValueToLower(bytes) == hash);
        }

        [TestMethod()]
        public void GetBytesValueToUpperTest()
        {
            string hash = "f29bc64a9d3732b4b9035125fdb3285f5b6455778edca72414671e0ca3b2e0de".ToUpper();
            string fileName = Path.Combine(Environment.CurrentDirectory, "TestFiles", "FileA.txt");
            var bytes = File.ReadAllBytes(fileName);
            Assert.IsTrue(SHA256Utils.GetBytesValueToUpper(bytes) == hash);
        }
    }
}