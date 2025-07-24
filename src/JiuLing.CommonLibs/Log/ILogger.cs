using System;

namespace JiuLing.CommonLibs.Log
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 设置日志文件的路径
        /// </summary>
        /// <returns></returns>
        ILogger SetLogDirectory(string path);

        /// <summary>
        /// 设置日志文件名的格式
        /// </summary>
        /// <returns></returns>
        ILogger SetFileNameFormat(string datetimeFormat);

        /// <summary>
        /// 设置日志文件扩展名
        /// </summary>
        /// <returns></returns>
        ILogger SetFileExpandedName(string expandedName);

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">日志内容</param>
        [Obsolete("请使用 Info() 方法替代。")]
        void Write(string message);

        /// <summary>
        /// 写入消息日志
        /// </summary>
        /// <param name="message">日志内容</param>
        void Info(string message);

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="ex">异常信息</param>
        void Error(string message, Exception ex = null);
    }
}
