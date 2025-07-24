using System;

namespace JiuLing.CommonLibs.Log
{
    /// <summary>
    /// 日志管理
    /// </summary>
    public static class LogManager
    {
        private static ILogger _logger;
        private static readonly object LockLogger = new object();
        /// <summary>
        /// 获取一个日志对象
        /// </summary>
        /// <returns></returns>
        public static ILogger GetLogger()
        {
            if (_logger != null)
            {
                return _logger;
            }
            lock (LockLogger)
            {
                if (_logger == null)
                {
                    _logger = new TextLogger();
                }
                return _logger;
            }
        }

        /// <summary>
        /// 注册日志写入异常回调
        /// </summary>
        /// <param name="callback">异常处理回调</param>
        public static void RegisterLogExceptionCallback(Action<Exception> callback)
        {
            if (_logger is TextLogger)
            {
                TextLogger.OnLogWriteException += callback;
            }
        }
    }
}
