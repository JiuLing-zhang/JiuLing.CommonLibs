namespace JiuLing.CommonLibs.Log
{
    public class LogManager
    {
        private static ILogger _logger;
        private static readonly object LockLogger = new();
        public static ILogger GetLogger()
        {
            if (_logger != null)
            {
                return _logger;
            }
            lock (LockLogger)
            {
                _logger ??= new TextLogger();
            }

            return _logger;
        }
    }
}
