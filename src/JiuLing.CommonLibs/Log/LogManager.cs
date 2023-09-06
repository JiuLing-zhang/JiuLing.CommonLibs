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
    }
}
