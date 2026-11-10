using System;
using JiuLing.CommonLibs.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.ExtensionMethods
{
    [TestClass()]
    public class StringExtensionTests
    {
        [TestMethod()]
        [DataRow("", false, true)]
        [DataRow(" ", false, false)]
        [DataRow("test", false, false)]
        [DataRow(" test   ", false, false)]
        [DataRow("", true, true)]
        [DataRow(" ", true, true)]
        [DataRow("test", true, false)]
        [DataRow(" test   ", true, false)]
        public void IsEmptyTest(string input, bool checkWhiteSpace, bool result)
        {
            Assert.AreEqual(input.IsEmpty(checkWhiteSpace), result);
        }

        [TestMethod()]
        [DataRow("test", false, true)]
        [DataRow(" test ", false, true)]
        [DataRow("", false, false)]
        [DataRow(" ", false, true)]
        [DataRow("test", true, true)]
        [DataRow(" test ", true, true)]
        [DataRow("", true, false)]
        [DataRow(" ", true, false)]
        public void IsNotEmptyTest(string input, bool checkWhiteSpace, bool result)
        {
            Assert.AreEqual(input.IsNotEmpty(checkWhiteSpace), result);
        }

        [TestMethod()]
        [DataRow("http://www.jiuling.me", true)]
        [DataRow("www.jiuling.com", false)]
        public void ToUriTest(string input, bool result)
        {
            if (result)
            {
                input.ToUri();
            }
            else
            {
                Assert.ThrowsException<UriFormatException>(() =>
                {
                    input.ToUri();
                });
            }
        }

        [TestMethod()]
        [DataRow("", 3, "...", "")]
        [DataRow("a", 3, "...", "a")]
        [DataRow("abc", 3, "...", "abc")]
        [DataRow("abcd", 3, "...", "abc...")]
        [DataRow("abcd", 3, "**", "abc**")]
        public void TruncateTest(string input, int maxLength, string ellipsis, string result)
        {
            Assert.IsTrue(input.Truncate(maxLength) == result);
        }

        [TestMethod()]
        [DataRow("aBc", true, "ABC")]
        [DataRow("aBc", false, "abc")]
        public void ToUpperOrLowerTest(string input, bool isToUpper, string result)
        {
            Assert.IsTrue(input.ToUpperOrLower(isToUpper) == result);
        }

        [TestMethod()]
        [DataRow("", "")]
        [DataRow("张", "张*")]
        [DataRow("张三", "张*")]
        [DataRow("张测试", "张**试")]
        [DataRow("张三测试", "张**试")]
        public void MaskNameTest(string input, string result)
        {
            Assert.IsTrue(input.MaskName() == result);
        }

        [TestMethod()]
        [DataRow("", "")]
        [DataRow("a", "a***")]
        [DataRow("ab", "a***")]
        [DataRow("abc", "a***c")]
        [DataRow("a@example.com", "a***@example.com")]
        [DataRow("ab@example.com", "a***@example.com")]
        [DataRow("abc@example.com", "a***c@example.com")]
        [DataRow("abcd@example.com", "a***d@example.com")]
        public void MaskEmailTest(string input, string result)
        {
            Assert.IsTrue(input.MaskEmail() == result);
        }
    }
}