using System;

namespace JiuLing.CommonLibs
{
    /// <summary>
    /// 程序版本帮助类
    /// </summary>
    public static class VersionUtils
    {
        /// <summary>
        /// 检查当前版本是否需要更新
        /// </summary>
        /// <param name="currentVersion">当前版本</param>
        /// <param name="newVersion">最新版本</param>
        /// <returns>返回是否需要更新</returns>
        public static bool CheckNeedUpdate(string currentVersion, string newVersion)
        {
            Version current = ToVersionWithBuild(currentVersion);
            Version version = ToVersionWithBuild(newVersion);
            return CheckNeedUpdate(current, version);
        }

        private static Version ToVersionWithBuild(string versionString)
        {
            if (Version.TryParse(versionString, out var version))
            {
                var build = version.Build;
                if (build == -1)
                {
                    build = 0;
                }
                var revision = version.Revision;
                if (revision == -1)
                {
                    revision = 0;
                }
                version = new Version(version.Major, version.Minor, build, revision);
            }
            return version;
        }

        /// <summary>
        /// 检查当前版本是否需要更新
        /// </summary>
        /// <param name="currentVersion">当前版本</param>
        /// <param name="newVersion">最新版本</param>
        /// <returns>返回是否需要更新</returns>
        public static bool CheckNeedUpdate(Version currentVersion, Version newVersion)
        {
            return currentVersion.CompareTo(newVersion) < 0;
        }

        /// <summary>
        /// 检查当前版本是否需要更新
        /// </summary>
        /// <param name="currentVersion">当前版本</param>
        /// <param name="newVersion">最新版本</param>
        /// <param name="minVersion">最小运行版本</param>
        /// <returns>返回（是否需要自动更新，当前版本是否允许使用）</returns>
        public static (bool IsNeedUpdate, bool IsAllowUse) CheckNeedUpdate(string currentVersion, string newVersion, string minVersion)
        {
            Version current = ToVersionWithBuild(currentVersion);
            Version version = ToVersionWithBuild(newVersion);
            Version min = ToVersionWithBuild(minVersion);
            return CheckNeedUpdate(current, version, min);
        }

        /// <summary>
        /// 检查当前版本是否需要更新
        /// </summary>
        /// <param name="currentVersion">当前版本</param>
        /// <param name="newVersion">最新版本</param>
        /// <param name="minVersion">最小运行版本</param>
        /// <returns>返回（是否需要自动更新，当前版本是否允许使用）</returns>
        public static (bool IsNeedUpdate, bool IsAllowUse) CheckNeedUpdate(Version currentVersion, Version newVersion, Version minVersion)
        {
            bool isNeedUpdate = CheckNeedUpdate(currentVersion, newVersion);
            int result = currentVersion.CompareTo(minVersion);
            if (result < 0)
            {
                return (isNeedUpdate, false);
            }
            else if (result == 0)
            {
                return (isNeedUpdate, true);
            }
            else
            {
                return (isNeedUpdate, true);
            }
        }
    }
}
