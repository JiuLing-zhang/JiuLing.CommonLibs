using System;
using JiuLing.CommonLibs.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace JiuLing.CommonLibs.UnitTests.ExtensionMethods
{
    [TestClass()]
    public class EnumExtensionTests
    {
        [TestMethod()]
        [DataRow(MyEnum.One, "一")]
        [DataRow(MyEnum.Two, "二")]
        [DataRow(MyEnum.Three, "Three")]
        public void GetDescriptionTest(Enum input, string result)
        {
            Assert.IsTrue(input.GetDescription() == result);
        }
    }

    public enum MyEnum
    {
        [Description("一")]
        One,
        [Description("二")]
        Two,
        Three
    }
}