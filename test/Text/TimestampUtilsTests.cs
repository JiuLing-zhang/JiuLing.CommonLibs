using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiuLing.CommonLibs.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuLing.CommonLibs.Text.Tests
{
    [TestClass()]
    public class TimestampHelperTests
    {
        [TestMethod()]
        [DataRow("2021-07-22 21:48:41", 1626961721)]
        public void ConvertToLen10Test(string timeString, Int64 result)
        {
            DateTime time = Convert.ToDateTime(timeString);
            Assert.IsTrue(TimestampHelper.ConvertToLen10(time) == result);
        }

        [TestMethod()]
        [DataRow("2021-07-22 21:48:41", 1626961721000)]
        public void ConvertToLen13Test(string timeString, Int64 result)
        {
            DateTime time = Convert.ToDateTime(timeString);
            Assert.IsTrue(TimestampHelper.ConvertToLen13(time) == result);
        }

        [TestMethod()]
        public void ConvertToDateTimeTest()
        {
            Int64 timeStamp = 1626961721000;
            DateTime time = Convert.ToDateTime("2021-07-22 21:48:41");
            Assert.IsTrue(DateTime.Compare(TimestampHelper.ConvertToDateTime(timeStamp), time) == 0);

            timeStamp = 1626961721;
            time = Convert.ToDateTime("2021-07-22 21:48:41");
            Assert.IsTrue(DateTime.Compare(TimestampHelper.ConvertToDateTime(timeStamp), time) == 0);

            timeStamp = 16269617210;
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TimestampHelper.ConvertToDateTime(timeStamp);
            });
        }
    }
}