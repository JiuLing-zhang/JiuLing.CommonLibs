using System;
using JiuLing.CommonLibs.Enums;

namespace JiuLing.CommonLibs.ExtensionMethods
{
    /// <summary>
    /// 版本号的扩展方法
    /// </summary>
    public static class VersionExtension
    {
        /// <summary>
        /// 格式化版本号
        /// </summary>
        /// <param name="version">版本号</param>
        /// <param name="format">格式化</param>
        /// <returns>格式化后的版本号字符串</returns>
        public static string ToFormatString(this Version version, VersionFormatEnum format)
        {
            switch (format)
            {
                case VersionFormatEnum.Major:
                    return version.Major.ToString();
                case VersionFormatEnum.MajorMinor:
                    return $"{version.Major}.{version.Minor}";
                case VersionFormatEnum.MajorMinorBuild:
                    return $"{version.Major}.{version.Minor}.{GetVersionBuild(version)}";
                case VersionFormatEnum.MajorMinorBuildRevision:
                    return $"{version.Major}.{version.Minor}.{GetVersionBuild(version)}.{GetVersionRevision(version)}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), "无效的版本格式");
            }
        }

        private static int GetVersionBuild(Version version)
        {
            var build = version.Build;
            if (build == -1)
            {
                build = 0;
            }
            return build;
        }
        private static int GetVersionRevision(Version version)
        {
            var revision = version.Revision;
            if (revision == -1)
            {
                revision = 0;
            }
            return revision;
        }
    }
}
