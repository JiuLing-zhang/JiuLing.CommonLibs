using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiuLing.CommonLibs.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuLing.CommonLibs.Log.Tests
{
    [TestClass()]
    public class LogManagerTests
    {
        [TestMethod()]
        public void GetLoggerTest()
        {
            Assert.IsTrue(LogManager.GetLogger() != null);
        }
    }
}