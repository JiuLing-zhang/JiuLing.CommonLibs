﻿namespace JiuLing.CommonLibs.Enums
{
    /// <summary>
    /// 版本号展示格式
    /// </summary>
    public enum VersionFormatEnum
    {
        /// <summary>
        /// 主版本（1）
        /// 例如：1
        /// </summary>
        Major = 1,
        /// <summary>
        /// 主版本.次版本
        /// 例如：1.2
        /// </summary>
        MajorMinor = 2,
        /// <summary>
        /// 主版本.次版本.构建版本
        /// 例如：1.2.3
        /// </summary>
        MajorMinorBuild = 3,
        /// <summary>
        /// 主版本.次版本.构建版本.修订版本
        /// 例如：1.2.3.4
        /// </summary>
        MajorMinorBuildRevision = 4
    }
}
