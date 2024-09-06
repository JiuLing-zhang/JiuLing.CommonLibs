using JiuLing.CommonLibs.Enums;
using JiuLing.CommonLibs.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JiuLing.CommonLibs.UnitTests.ExtensionMethods
{
    [TestClass()]
    public class VersionExtensionTests
    {
        [TestMethod()]
        [DataRow("1.2", VersionFormatEnum.Major, "1")]
        [DataRow("1.2", VersionFormatEnum.MajorMinor, "1.2")]
        [DataRow("1.2", VersionFormatEnum.MajorMinorBuild, "1.2.0")]
        [DataRow("1.2", VersionFormatEnum.MajorMinorBuildRevision, "1.2.0.0")]
        [DataRow("1.2.3", VersionFormatEnum.Major, "1")]
        [DataRow("1.2.3", VersionFormatEnum.MajorMinor, "1.2")]
        [DataRow("1.2.3", VersionFormatEnum.MajorMinorBuild, "1.2.3")]
        [DataRow("1.2.3", VersionFormatEnum.MajorMinorBuildRevision, "1.2.3.0")]
        [DataRow("1.2.3.4", VersionFormatEnum.Major, "1")]
        [DataRow("1.2.3.4", VersionFormatEnum.MajorMinor, "1.2")]
        [DataRow("1.2.3.4", VersionFormatEnum.MajorMinorBuild, "1.2.3")]
        [DataRow("1.2.3.4", VersionFormatEnum.MajorMinorBuildRevision, "1.2.3.4")]
        public void ToFormatVersionTest1(string input, VersionFormatEnum format, string result)
        {
            var version = new Version(input);
            var value = version.ToFormatString(format);
            Assert.AreEqual(value, result);
        }

        [TestMethod()]
        public void ToFormatVersionTest1_ArgumentOutOfRangeException()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                (new Version("1.2")).ToFormatString((VersionFormatEnum)0);
            });

            Assert.AreEqual("format", exception.ParamName);
            Assert.IsTrue(exception.Message.IndexOf("无效的版本格式") >= 0);
        }
    }
}