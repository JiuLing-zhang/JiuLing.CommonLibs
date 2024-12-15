using System.Collections.Generic;
using System.Linq;
using JiuLing.CommonLibs.Security.Signature;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.Security.Signature
{
    [TestClass()]
    public class SignatureBuilderTests
    {
        //param1=1&param3=3+&param2=2
        private readonly Dictionary<string, string> _signSource = new Dictionary<string, string>()
        {
            { "param1", "1" },
            { "param3", "3+" },
            { "param2", "2" }
        };

        [TestMethod()]
        public void CreateTest1()
        {
            var items = _signSource.Select(x => $"{x.Key}={x.Value}").ToList();
            var result = string.Join("&", items);

            var builder = SignatureBuilder.Create(_signSource);
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("param1=1&param3=3+&param2=2", "param1=1&param3=3+&param2=2")]
        public void CreateTest2(string input, string result)
        {
            var builder = SignatureBuilder.Create(input);
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "")]
        [DataRow("param1=1&param3=3&param2=2", "1&3&2")]
        public void FetchParameterValueTest1(string input, string result)
        {
            var builder = SignatureBuilder.Create(input).FetchParameterValue();
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "", "")]
        [DataRow("param1=1&param3=3&param2=2", "", "132")]
        [DataRow("param1=1&param3=3&param2=2", "&", "1&3&2")]
        public void FetchParameterValueTest2(string input, string separator, string result)
        {
            var builder = SignatureBuilder.Create(input).FetchParameterValue(separator);
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "")]
        [DataRow("param1=1&param3=3&param2=2", "param11param33param22")]
        public void FetchParameterNameAndValueTest1(string input, string result)
        {
            var builder = SignatureBuilder.Create(input).FetchParameterNameAndValue();
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "", "")]
        [DataRow("param1=1&param3=3&param2=2", "", "param11param33param22")]
        [DataRow("param1=1&param3=3&param2=2", "+", "param11+param33+param22")]
        [DataRow("param1=1&param3=3&param2=2", "&", "param11&param33&param22")]
        public void FetchParameterNameAndValueTest2(string input, string separator, string result)
        {
            var builder = SignatureBuilder.Create(input).FetchParameterNameAndValue(separator);
            Assert.IsTrue(result == builder.GetResult());
        }


        [TestMethod()]
        [DataRow("", "")]
        [DataRow("param3=3+&param1=1&param2=2", "param1=1&param2=2&param3=3+")]
        public void OrderByAsyncTest(string input, string result)
        {
            var builder = SignatureBuilder.Create(input).OrderBy();
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "")]
        [DataRow("test1=1&test2=2", "dGVzdDE9MSZ0ZXN0Mj0y")]
        public void Base64Test(string input, string result)
        {
            var builder = SignatureBuilder.Create(input).Base64();
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "", "")]
        [DataRow("test1=1&test2=2", "appKey", "appKeytest1=1&test2=2")]
        public void PrefixTest(string input, string prefix, string result)
        {
            var builder = SignatureBuilder.Create(input).Prefix(prefix);
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "", "")]
        [DataRow("test1=1&test2=2", "appKey", "test1=1&test2=2appKey")]
        public void PostfixTest(string input, string postfix, string result)
        {
            var builder = SignatureBuilder.Create(input).Postfix(postfix);
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "d41d8cd98f00b204e9800998ecf8427e")]
        [DataRow("test1=1&test2=2", "ee2511b7137adee95204899d1855eb3f")]
        public void MD5Test(string input, string result)
        {
            var builder = SignatureBuilder.Create(input).MD5();
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "da39a3ee5e6b4b0d3255bfef95601890afd80709")]
        [DataRow("test1=1&test2=2", "e4e44e7539fff69b6fb984ef206aedaf9b3c650f")]
        public void SHA1Test(string input, string result)
        {
            var builder = SignatureBuilder.Create(input).SHA1();
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855")]
        [DataRow("test1=1&test2=2", "8ebc3e5c2302d3500e7a7e1dcb5e9ff65d1b0c304133cca9cb656e8f67275a9e")]
        public void SHA256Test(string input, string result)
        {
            var builder = SignatureBuilder.Create(input).SHA256();
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "")]
        [DataRow("test1=1&test2=2", "TEST1=1&TEST2=2")]
        public void ToUpperTest(string input, string result)
        {
            var builder = SignatureBuilder.Create(input).ToUpper();
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "")]
        [DataRow("Test1=1&Test2=2", "test1=1&test2=2")]
        public void ToLowerTest(string input, string result)
        {
            var builder = SignatureBuilder.Create(input).ToLower();
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "")]
        [DataRow("param1=1&param3=3+&param2=2", "param1%3D1%26param3%3D3%2B%26param2%3D2")]
        public void UrlEncodeUpperTest(string input, string result)
        {
            var builder = SignatureBuilder.Create(input).UrlEncodeUpper();
            Assert.IsTrue(result == builder.GetResult());
        }

        [TestMethod()]
        [DataRow("", "")]
        [DataRow("param1=1&param3=3+&param2=2", "param1%3d1%26param3%3d3%2b%26param2%3d2")]
        public void UrlEncodeLowerTest(string input, string result)
        {
            var builder = SignatureBuilder.Create(input).UrlEncodeLower();
            Assert.IsTrue(result == builder.GetResult());
        }
    }
}