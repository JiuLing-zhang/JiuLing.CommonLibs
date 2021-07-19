using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiuLing.CommonLibs.Text;
using System.Linq;

namespace JiuLing.CommonLibs.TextTests
{
    [TestClass()]
    public class RegexHelperTests
    {
        private readonly RegexHelper _regexHelper = new();

        [TestMethod()]
        [DataRow("11", @"\d{3}", false)]
        [DataRow("111", @"\d{3}", true)]
        public void IsMatchTest(string input, string pattern, bool result)
        {
            Assert.AreEqual(_regexHelper.IsMatch(input, pattern), result);
        }

        [TestMethod()]
        [DataRow("test1", @"test\d{2}", null)]
        [DataRow("test12", @"test\d{2}", "test12")]
        [DataRow("test123", @"test\d{2}", "test12")]
        [DataRow("test123test456", @"test\d{2}", "test12")]
        public void GetFirstTest(string input, string pattern, object result)
        {
            Assert.AreEqual(_regexHelper.GetFirst(input, pattern), result);
        }

        [TestMethod()]
        [DataRow("test1", @"test\d{2}", "")]
        [DataRow("test12", @"test\d{2}", "test12")]
        [DataRow("test123", @"test\d{2}", "test12")]
        [DataRow("test123test456", @"test\d{2}", "test12")]
        public void GetFirstOrDefaultTest(string input, string pattern, string result)
        {
            Assert.AreEqual(_regexHelper.GetFirstOrDefault(input, pattern), result);
        }
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
            List<string> realResult = _regexHelper.GetAll(input, pattern);
            Assert.IsTrue(realResult.SequenceEqual(result));
        }
    }
}