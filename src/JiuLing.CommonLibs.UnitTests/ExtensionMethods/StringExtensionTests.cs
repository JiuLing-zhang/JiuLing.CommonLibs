﻿using System;
using JiuLing.CommonLibs.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.ExtensionMethods
{
    [TestClass()]
    public class StringExtensionTests
    {
        [TestMethod()]
        [DataRow("", true)]
        [DataRow("test", false)]
        public void IsEmptyTest(string input, bool result)
        {
            Assert.AreEqual(input.IsEmpty(), result);
        }

        [TestMethod()]
        [DataRow("test", true)]
        [DataRow("", false)]
        public void IsNotEmptyTest(string input, bool result)
        {
            Assert.AreEqual(input.IsNotEmpty(), result);
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
    }
}