using JiuLing.CommonLibs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace JiuLing.CommonLibs.Tests
{
    [TestClass()]
    public class TempIdGeneratorTests
    {
        private const int _minLength = 2;
        private const int _maxLength = 6;

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TempIdGeneratorMinValueTest()
        {
            new TempIdGenerator(_minLength - 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TempIdGeneratorMaxValueTest()
        {
            new TempIdGenerator(_maxLength + 1);
        }

        [TestMethod()]
        public void TempIdGeneratorTest()
        {
            new TempIdGenerator(_minLength);
            new TempIdGenerator(_maxLength);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        [DataRow(_minLength)]
        public void CreateByTimeSpanTest(int idLength)
        {
            var time = DateTime.Now;
            TimeSpan expiration = time.AddSeconds(5).Subtract(time);
            var tempIdGenerator = new TempIdGenerator(idLength);

            var minString = "1".PadRight(idLength, '0');
            var maxString = $"{minString}0";

            var minValue = Convert.ToInt32(minString);
            var maxValue = Convert.ToInt32(maxString);

            //生成的 id 集合
            List<int> ids = new List<int>(maxValue - minValue);
            for (int i = minValue; i < maxValue; i++)
            {
                var tempId = tempIdGenerator.Create(expiration);
                Assert.IsFalse(tempId == 0);
                ids.Add(tempId);
            }

            System.Threading.Thread.Sleep(5000);
            ids = new List<int>(maxValue - minValue);
            for (int i = minValue; i < maxValue; i++)
            {
                var tempId = tempIdGenerator.Create(expiration);
                Assert.IsFalse(tempId == 0);
                ids.Add(tempId);
            }
        }

        [TestMethod()]
        [DataRow(_minLength)]
        public void CreateByDateTimeTest(int idLength)
        {
            DateTime expiration = DateTime.Now.AddSeconds(5);
            var tempIdGenerator = new TempIdGenerator(idLength);

            var minString = "1".PadRight(idLength, '0');
            var maxString = $"{minString}0";

            var minValue = Convert.ToInt32(minString);
            var maxValue = Convert.ToInt32(maxString);

            //生成的 id 集合
            List<int> ids = new List<int>(maxValue - minValue);
            for (int i = minValue; i < maxValue; i++)
            {
                var tempId = tempIdGenerator.Create(expiration);
                Assert.IsFalse(tempId == 0);
                ids.Add(tempId);
            }

            System.Threading.Thread.Sleep(5000);
            ids = new List<int>(maxValue - minValue);
            for (int i = minValue; i < maxValue; i++)
            {
                var tempId = tempIdGenerator.Create(expiration);
                Assert.IsFalse(tempId == 0);
                ids.Add(tempId);
            }
        }
    }
}