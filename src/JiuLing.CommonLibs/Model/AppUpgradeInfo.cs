using System;

namespace JiuLing.CommonLibs.Model
{
    /// <summary>
    /// 一个通用的App自动更新所需的模型
    /// </summary>
    public class AppUpgradeInfo
    {
        /// <summary>
        /// 程序名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public int? VersionCode { get; set; }
        /// <summary>
        /// 当前版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 程序运行的最小版本
        /// </summary>
        public string MinVersion { get; set; }
        /// <summary>
        /// 下载地址
        /// </summary>
        public string DownloadUrl { get; set; }
        /// <summary>
        /// 更新日志
        /// </summary>
        public string Log { get; set; }
        /// <summary>
        /// 文件签名类型（例如 MD5、SHA1 等）
        /// </summary>
        public string SignType { get; set; }
        /// <summary>
        /// 签名值
        /// </summary>
        public string SignValue { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public int? FileLength { get; set; }
    }
}
