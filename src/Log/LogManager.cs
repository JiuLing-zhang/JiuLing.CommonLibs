namespace JiuLing.CommonLibs.Log
{
    public class LogManager
    {
        private static ILogger _logger;
        private static readonly object LockLogger = new object();
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
