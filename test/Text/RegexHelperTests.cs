using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiuLing.CommonLibs.Text;

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
    }
}