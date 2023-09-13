using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests
{
    [TestClass()]
    public class VersionUtilsTests
    {

        [TestMethod()]
        [DataRow("1.0.0", "1.0.0", false)]
        [DataRow("1.0.0", "1.0.0.0", false)]
        [DataRow("1.0.0.0", "1.0.0", false)]
        [DataRow("1.0", "1.0.0", false)]
        [DataRow("1.0.0", "1.0", false)]
        [DataRow("1.0.0", "1.0.2", true)]
        [DataRow("2.0.0.0", "2.0.0.0", false)]
        [DataRow("2.1.0.0", "3.0.0.0", true)]
        public void CheckNeedUpdate1Test(string currentVersion, string newVersion, bool isNeedUpdate)
        {
            Assert.IsTrue(isNeedUpdate == VersionUtils.CheckNeedUpdate(currentVersion, newVersion));
        }

        [TestMethod()]
        [DataRow("1.0.0", "1.0.0", false)]
        [DataRow("1.0.0", "1.0.2", true)]
        [DataRow("2.0.0.0", "2.0.0.0", false)]
        [DataRow("2.1.0.0", "3.0.0.0", true)]
        public void CheckNeedUpdate2Test(string currentVersion, string newVersion, bool isNeedUpdate)
        {
            Assert.IsTrue(isNeedUpdate == VersionUtils.CheckNeedUpdate(new Version(currentVersion), new Version(newVersion)));
        }

        [TestMethod()]
        [DataRow("1.0.0", "1.0.2", "1.0.0", true, true)]
        [DataRow("1.0.0", "1.0.2", "1.0.1", true, false)]
        [DataRow("1.0.0", "1.0.0", "1.0.0", false, true)]
        public void CheckNeedUpdate3Test(string currentVersion, string newVersion, string minVersion, bool isNeedUpdate, bool isAllowUse)
        {
            var cv = new Version(currentVersion);
            var nv = new Version(newVersion);
            var mv = new Version(minVersion);
            var result = VersionUtils.CheckNeedUpdate(cv, nv, mv);
            Assert.IsTrue(result == (isNeedUpdate, isAllowUse));
        }

        [TestMethod()]
        [DataRow("1.0.0", "1.0.2", "1.0.0", false, true)]
        [DataRow("1.0.0", "1.0.2", "1.0.1", true, false)]
        [DataRow("1.0.0", "1.0.0", "1.0.0", false, true)]
        [DataRow("1.0.0", "1.0.0.0", "1.0.0", false, true)]
        [DataRow("1.1.0", "1.2.0.0", "1.1.0.0", false, true)]
        [DataRow("1.0.0", "1.2.0.0", "1.1.0.0", true, false)]
        public void CheckNeedUpdate4Test(string currentVersion, string newVersion, string minVersion, bool isNeedUpdate, bool isAllowUse)
        {
            var result = VersionUtils.CheckNeedUpdate(currentVersion, newVersion, minVersion);
            Assert.IsTrue(result == (isNeedUpdate, isAllowUse));
        }
    }
}