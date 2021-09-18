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
    public class TimestampUtilsTests
    {

        [TestMethod()]
        public void GetLen10Test()
        {
            Assert.IsTrue(TimestampUtils.GetLen10().ToString().Length == 10);
        }

        [TestMethod()]
        public void GetLen13Test()
        {
            Assert.IsTrue(TimestampUtils.GetLen13().ToString().Length == 13);
        }

        [TestMethod()]
        public void ConvertToLen10Test()
        {
            DateTime time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Int64 timestamp = TimestampUtils.ConvertToLen10(time);
            Assert.IsTrue(DateTime.Compare(TimestampUtils.ConvertToDateTime(timestamp), time) == 0);
        }

        [TestMethod()]
        public void ConvertToLen13Test()
        {
            DateTime time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Int64 timestamp = TimestampUtils.ConvertToLen13(time);
            Assert.IsTrue(DateTime.Compare(TimestampUtils.ConvertToDateTime(timestamp), time) == 0);
        }

        [TestMethod()]
        public void ConvertToDateTimeTest()
        {
            DateTime time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Int64 timestamp = TimestampUtils.ConvertToLen10(time);
            Assert.IsTrue(DateTime.Compare(TimestampUtils.ConvertToDateTime(timestamp), time) == 0);
        }

    }
}
