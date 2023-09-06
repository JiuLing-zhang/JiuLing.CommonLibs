using System.Collections.Generic;
using JiuLing.CommonLibs.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.Random
{
    [TestClass()]
    public class RandomUtilsTests
    {
        [TestMethod()]
        [DataRow(0)]
        [DataRow(3)]
        [DataRow(5)]
        public void GetOneTest(int randomLength)
        {
            Assert.IsTrue(RandomUtils.GetOneByLength(randomLength).Length == randomLength);
        }

        [TestMethod()]
        public void GetOneFromListTest()
        {
            var list = new List<string>();
            string result = RandomUtils.GetOneFromList<string>(list);
            Assert.IsTrue(result.IsEmpty());
            list.Add("a");
            list.Add("b");
            result = RandomUtils.GetOneFromList<string>(list);
            Assert.IsTrue(list.Contains(result));
        }


        [TestMethod()]
        [DataRow(0)]
        [DataRow(3)]
        [DataRow(5)]
        public void GetOneHexByLengthToLowerTest(int randomLength)
        {
            Assert.IsTrue(RandomUtils.GetOneHexByLengthToLower(randomLength).Length == randomLength * 2);
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(3)]
        [DataRow(5)]
        public void GetOneHexByLengthToUpperTest(int randomLength)
        {
            Assert.IsTrue(RandomUtils.GetOneHexByLengthToUpper(randomLength).Length == randomLength * 2);
        }
    }
}