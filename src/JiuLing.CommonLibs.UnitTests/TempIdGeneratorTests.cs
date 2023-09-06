using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests
{
    [TestClass()]
    public class TempIdGeneratorTests
    {
        private const int MinLength = 2;
        private const int MaxLength = 6;

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TempIdGeneratorMinValueTest()
        {
            new TempIdGenerator(MinLength - 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TempIdGeneratorMaxValueTest()
        {
            new TempIdGenerator(MaxLength + 1);
        }

        [TestMethod()]
        public void TempIdGeneratorTest()
        {
            new TempIdGenerator(MinLength);
            new TempIdGenerator(MaxLength);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        [DataRow(MinLength)]
        public void CreateByTimeSpanTest(int idLength)
        {
            var time = DateTime.Now;
            TimeSpan expiration = time.AddSeconds(5).Subtract(time);
            var tempIdGenerator = new TempIdGenerator(idLength);

            var minString = "1".PadRight(idLength, '0');
            var maxString = $"{minString}0";

            var minValue = Convert.ToInt32(minString);
            var maxValue = Convert.ToInt32(maxString);

            for (int i = minValue; i < maxValue; i++)
            {
                var tempId = tempIdGenerator.Create(expiration);
                Assert.IsFalse(tempId == 0);
            }

            System.Threading.Thread.Sleep(5000);
            for (int i = minValue; i < maxValue; i++)
            {
                var tempId = tempIdGenerator.Create(expiration);
                Assert.IsFalse(tempId == 0);
            }
        }

        [TestMethod()]
        [DataRow(MinLength)]
        public void CreateByDateTimeTest(int idLength)
        {
            DateTime expiration = DateTime.Now.AddSeconds(5);
            var tempIdGenerator = new TempIdGenerator(idLength);

            var minString = "1".PadRight(idLength, '0');
            var maxString = $"{minString}0";

            var minValue = Convert.ToInt32(minString);
            var maxValue = Convert.ToInt32(maxString);

            for (int i = minValue; i < maxValue; i++)
            {
                var tempId = tempIdGenerator.Create(expiration);
                Assert.IsFalse(tempId == 0);
            }

            System.Threading.Thread.Sleep(5000);
            for (int i = minValue; i < maxValue; i++)
            {
                var tempId = tempIdGenerator.Create(expiration);
                Assert.IsFalse(tempId == 0);
            }
        }
    }
}