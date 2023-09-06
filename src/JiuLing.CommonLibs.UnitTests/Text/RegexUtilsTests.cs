using System.Collections.Generic;
using System.Linq;
using JiuLing.CommonLibs.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.Text
{
    [TestClass()]
    public class RegexUtilsTests
    {
        [TestMethod()]
        [DataRow("11", @"\d{3}", false)]
        [DataRow("111", @"\d{3}", true)]
        public void IsMatchTest(string input, string pattern, bool result)
        {
            Assert.AreEqual(RegexUtils.IsMatch(input, pattern), result);
        }

        [TestMethod()]
        [DataRow("?<name>", @"[^a-zA-Z]", "", "name")]
        [DataRow("<test>", @"test", "xxx", "<xxx>")]
        public void ReplaceTest(string input, string pattern, string replacement, string result)
        {
            Assert.IsTrue(RegexUtils.Replace(input, pattern, replacement) == result);
        }

        [TestMethod()]
        [DataRow("test1", @"test\d{2}", false, "")]
        [DataRow("test12", @"test\d{2}", true, "test12")]
        [DataRow("test123", @"test\d{2}", true, "test12")]
        [DataRow("test123test456", @"test\d{2}", true, "test12")]
        public void GetFirstTest(string input, string pattern, bool success, string result)
        {
            var (realSuccess, realResult) = RegexUtils.GetFirst(input, pattern);
            Assert.IsTrue(success == realSuccess && result == realResult);
        }

        //GetAll方法的测试用例
        private static IEnumerable<object[]> GetAllData
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        "test1",
                        @"test\d{2}",
                        new List<string>()
                    },
                    new object[]
                    {
                        "test123",
                        @"test\d{2}",
                        new List<string>{ "test12" }
                    },
                    new object[]
                    {
                        "test123test456",
                        @"test\d{2}",
                        new List<string>{ "test12", "test45" }
                    }
                };
            }
        }

        [TestMethod()]
        [DynamicData(nameof(GetAllData))]
        public void GetAllTest(string input, string pattern, List<string> result)
        {
            List<string> realResult = RegexUtils.GetAll(input, pattern);
            Assert.IsTrue(realResult.SequenceEqual(result));
        }


        private static IEnumerable<object[]> GetOneGroupAllMatchData
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        "<div>a1</div><div>a2</div><div>a3</div>",
                        @"<div>[\s\S]*?<\/div>",
                        new List<string>()
                    },
                    new object[]
                    {
                        "<div>a1</div><div>a2</div><div>a3</div>",
                        @"<div>(?<value>[\s\S]*?)<\/div>",
                        new List<string>{ "a1", "a2", "a3" }
                    }
                };
            }
        }

        [TestMethod()]
        [DynamicData(nameof(GetOneGroupAllMatchData))]
        public void GetOneGroupAllMatchTest(string input, string pattern, List<string> result)
        {
            List<string> realResult = RegexUtils.GetOneGroupAllMatch(input, pattern);
            Assert.IsTrue(realResult.SequenceEqual(result));
        }

        [TestMethod()]
        [DataRow("name:jiuling;age:0;", @"name:\w*;", false, "")]
        [DataRow("name:jiuling;age:0;", @"name:(?<name>\w*);age:(?<age>\w*);", false, "")]
        [DataRow("name:jiuling;age:0;", @"name:(?<name>\w*);", true, "jiuling")]
        public void GetOneGroupInFirstMatchTest(string input, string pattern, bool success, string result)
        {
            var (realSuccess, realResult) = RegexUtils.GetOneGroupInFirstMatch(input, pattern);
            Assert.IsTrue(success == realSuccess && result == realResult);
        }

        [TestMethod()]
        public void GetMultiGroupInFirstMatchTest()
        {
            //无分组
            string input = "name:jiuling;age:0;";
            string pattern = @"name:\w*;";
            bool realSuccess;
            (realSuccess, _) = RegexUtils.GetMultiGroupInFirstMatch(input, pattern);
            Assert.IsFalse(realSuccess);

            //一个分组
            input = "name:jiuling;age:0;";
            pattern = @"name:(?<name>\w*);";

            IDictionary<string, string> realResult;
            (realSuccess, realResult) = RegexUtils.GetMultiGroupInFirstMatch(input, pattern);
            Assert.IsTrue(realSuccess && realResult["name"] == "jiuling");

            //多个分组
            input = "name:jiuling;age:0;";
            pattern = @"name:(?<name>\w*);age:(?<age>\w*);";
            (realSuccess, realResult) = RegexUtils.GetMultiGroupInFirstMatch(input, pattern);
            Assert.IsTrue(realSuccess && realResult["name"] == "jiuling" && realResult["age"] == "0");
        }


    }
}