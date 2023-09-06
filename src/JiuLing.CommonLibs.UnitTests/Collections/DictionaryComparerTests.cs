using System.Collections.Generic;
using JiuLing.CommonLibs.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.Collections
{
    [TestClass()]
    public class DictionaryComparerTests
    {
        private readonly DictionaryComparer<string, string> _myComparer = new DictionaryComparer<string, string>();
        [TestMethod()]
        [Ignore(message: "构造函数，不测试")]
        public void DictionaryComparerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var x = new Dictionary<string, string>();
            var y = new Dictionary<string, string>();

            Assert.IsFalse(_myComparer.Equals(x, null));
            Assert.IsFalse(_myComparer.Equals(null, y));
            Assert.IsTrue(_myComparer.Equals(x, y));

            x.Add("a1", "b1");
            x.Add("a2", "b2");
            y.Add("a1", "b1");
            y.Add("a2", "b2");
            Assert.IsTrue(_myComparer.Equals(x, y));

            x.Add("a3", "b3");
            Assert.IsFalse(_myComparer.Equals(x, y));
            y.Add("a3", "b33");
            Assert.IsFalse(_myComparer.Equals(x, y));
        }

        [TestMethod()]
        [Ignore(message: "未实现的方法，不测试")]
        public void GetHashCodeTest()
        {
            Assert.Fail();
        }
    }
}