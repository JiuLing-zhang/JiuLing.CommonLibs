﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiuLing.CommonLibs.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuLing.CommonLibs.Random.Tests
{
    [TestClass()]
    public class RandomHelperTests
    {
        [TestMethod()]
        [DataRow(0)]
        [DataRow(3)]
        [DataRow(5)]
        public void GetOneTest(int randomLength)
        {
            Assert.IsTrue(RandomHelper.GetOne(randomLength).Length == randomLength);
        }
    }
}