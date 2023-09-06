using System.Diagnostics;
using JiuLing.CommonLibs.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.Threading
{
    [TestClass()]
    public class ThreadUtilsTests
    {
        [TestMethod()]
        [DataRow(1, 2)]
        [DataRow(0, 5)]
        public void SleepRandomSecondTest(int minValue, int maxValue)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            ThreadUtils.SleepRandomSecond(minValue, maxValue);
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
            ThreadUtils.SleepRandomMillisecond(minValue, maxValue);
            stopwatch.Stop();
            var sleepMilliseconds = stopwatch.ElapsedMilliseconds;
            Assert.IsTrue(sleepMilliseconds >= minValue && sleepMilliseconds <= maxValue);
        }
    }
}