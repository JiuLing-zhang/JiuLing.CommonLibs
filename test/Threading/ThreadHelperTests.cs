using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiuLing.CommonLibs.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuLing.CommonLibs.Threading.Tests
{
    [TestClass()]
    public class ThreadHelperTests
    {
        [TestMethod()]
        [DataRow(1, 2)]
        [DataRow(0, 5)]
        public void SleepRandomSecondTest(int minValue, int maxValue)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            ThreadHelper.SleepRandomSecond(minValue, maxValue);
            stopwatch.Stop();
            var sleepMilliseconds = stopwatch.ElapsedMilliseconds / 1000;
            Assert.IsTrue(sleepMilliseconds >= minValue && sleepMilliseconds <= maxValue);
        }

        [TestMethod()]
        [DataRow(1000, 2000)]
        [DataRow(0, 5000)]
        public void SleepRandomMillisecondTest(int minValue, int maxValue)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            ThreadHelper.SleepRandomMillisecond(minValue, maxValue);
            stopwatch.Stop();
            var sleepMilliseconds = stopwatch.ElapsedMilliseconds;
            Assert.IsTrue(sleepMilliseconds >= minValue && sleepMilliseconds <= maxValue);
        }
    }
}