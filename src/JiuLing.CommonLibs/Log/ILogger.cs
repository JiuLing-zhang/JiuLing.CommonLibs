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
        void Write(string message);
    }
}
