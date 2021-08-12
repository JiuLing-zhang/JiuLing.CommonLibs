using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiuLing.CommonLibs.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DescriptionAttribute = JiuLing.CommonLibs.ExtensionAttributes.DescriptionAttribute;

namespace JiuLing.CommonLibs.ExtensionMethods.Tests
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