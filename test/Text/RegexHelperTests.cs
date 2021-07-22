using JiuLing.CommonLibs.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace JiuLing.CommonLibs.TextTests
{

    [TestClass()]
    public class RegexHelperTests
    {
        private readonly RegexTool _regexTool = new();

        [TestMethod()]
        [DataRow("11", @"\d{3}", false)]
        [DataRow("111", @"\d{3}", true)]
        public void IsMatchTest(string input, string pattern, bool result)
        {
            Assert.AreEqual(_regexTool.IsMatch(input, pattern), result);
        }

        [TestMethod()]
        [DataRow("test1", @"test\d{2}", false, "")]
        [DataRow("test12", @"test\d{2}", true, "test12")]
        [DataRow("test123", @"test\d{2}", true, "test12")]
        [DataRow("test123test456", @"test\d{2}", true, "test12")]
        public void GetFirstTest(string input, string pattern, bool success, string result)
        {
            var (realSuccess, realResult) = _regexTool.GetFirst(input, pattern);
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
            List<string> realResult = _regexTool.GetAll(input, pattern);
            Assert.IsTrue(realResult.SequenceEqual(result));
        }


        [TestMethod()]
        [DataRow("name:jiuling;age:0;", @"name:\w*;", false, "")]
        [DataRow("name:jiuling;age:0;", @"name:(?<name>\w*);age:(?<age>\w*);", false, "")]
        [DataRow("name:jiuling;age:0;", @"name:(?<name>\w*);", true, "jiuling")]
        public void GetOneGroupInFirstMatchTest(string input, string pattern, bool success, string result)
        {
            var (realSuccess, realResult) = _regexTool.GetOneGroupInFirstMatch(input, pattern);
            Assert.IsTrue(success == realSuccess && result == realResult);
        }

        [TestMethod()]
        public void GetMultiGroupInFirstMatchTest()
        {
            //无分组
            string input = "name:jiuling;age:0;";
            string pattern = @"name:\w*;";
            List<string> groupNames = new List<string>() { "name" };
            bool realSuccess;
            dynamic realResult;
            (realSuccess, _) = _regexTool.GetMultiGroupInFirstMatch(input, pattern, groupNames);
            Assert.IsFalse(realSuccess);

            //一个分组
            input = "name:jiuling;age:0;";
            pattern = @"name:(?<name>\w*);";
            groupNames = new List<string>() { "name" };

            (realSuccess, realResult) = _regexTool.GetMultiGroupInFirstMatch(input, pattern, groupNames);
            Assert.IsTrue(realSuccess && realResult.name == "jiuling");

            //多个分组
            input = "name:jiuling;age:0;";
            pattern = @"name:(?<name>\w*);age:(?<age>\w*);";
            groupNames = new List<string>() { "name", "age" };
            (realSuccess, realResult) = _regexTool.GetMultiGroupInFirstMatch(input, pattern, groupNames);
            Assert.IsTrue(realSuccess && realResult.name == "jiuling" && realResult.age == "0");
        }
    }
}