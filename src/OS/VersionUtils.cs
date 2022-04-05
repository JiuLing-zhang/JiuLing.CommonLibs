using System;
using System.ComponentModel;

namespace JiuLing.CommonLibs.OS
{
    /// <summary>
    /// 系统版本的相关工具
    /// </summary>
    public class VersionUtils
    {
        /// <summary>
        /// 是否为Win7
        /// </summary>
        public static bool IsWindows7 => Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1;
        /// <summary>
        /// 是否为Win8
        /// </summary>
        public static bool IsWindows8 => Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 2;
        /// <summary>
        /// 是否为Win8.1
        /// </summary>
        public static bool IsWindows81 => Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 3;
        /// <summary>
        /// 是否为Win10
        /// </summary>
        public static bool IsWindows10 => Environment.OSVersion.Version.Major == 10;

        /// <summary>
        /// 获取当前系统的版本
        /// </summary>
        /// <returns>返回一个版本信息，判断不出来时返回Unknown</returns>
        public static OSVersionEnum GetOSVersion()
        {
            if (IsWindows7)
            {
                return OSVersionEnum.Windows7;
            }
            if (IsWindows8)
            {
                return OSVersionEnum.Windows8;
            }
            if (IsWindows81)
            {
                return OSVersionEnum.Windows81;
            }
            if (IsWindows10)
            {
                return OSVersionEnum.Windows10;
            }
            return OSVersionEnum.Unknown;
        }
    }
    /// <summary>
    /// 操作系统的版本
    /// </summary>
    public enum OSVersionEnum
    {
        /// <summary>
        /// Win7
        /// </summary>
        [Description("Windows7")]
        Windows7,
        /// <summary>
        /// Win8
        /// </summary>
        [Description("Windows8")]
        Windows8,
        /// <summary>
        /// Win8.1
        /// </summary>
        [Description("Windows8.1")]
        Windows81,
        /// <summary>
        /// Win10
        /// </summary>
        [Description("Windows10")]
        Windows10,
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown,
    }
}
