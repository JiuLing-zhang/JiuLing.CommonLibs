using JiuLing.CommonLibs.ExtensionMethods;
using System;
using System.IO;

namespace JiuLing.CommonLibs.Log
{
    /// <summary>
    /// 文本日志
    /// </summary>
    internal class TextLogger : ILogger
    {
        private string _logDirectory;
        private string _logNameDatetimeFormat;
        private string _logExpandedName;
        /// <summary>
        /// 不同日志级别是否单独记录到不同文件
        /// </summary>
        private bool _separateByLogLevel;
        private static readonly object LockObj = new object();

        /// <summary>
        /// 异常回调，供LogManager注册使用
        /// </summary>
        internal static Action<Exception> OnLogWriteException { get; set; }

        /// <summary>
        /// 实例化
        /// </summary>
        public TextLogger()
        {
            _logDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log"));
            _logNameDatetimeFormat = "yyyy-MM-dd";
            _logExpandedName = ".log";
            _separateByLogLevel = true;
        }

        /// <summary>
        /// 设置日志目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public ILogger SetLogDirectory(string path)
        {
            if (path.IsEmpty())
            {
                throw new ArgumentException("日志路径不能为空", nameof(path));
            }

            lock (LockObj)
            {
                _logDirectory = Path.GetFullPath(path);
            }

            return this;
        }

        /// <summary>
        /// 设置日志文件名格式
        /// </summary>
        /// <param name="datetimeFormat"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public ILogger SetFileNameFormat(string datetimeFormat)
        {
            if (datetimeFormat.IsEmpty())
            {
                throw new ArgumentException("时间格式化规则不能为空", nameof(datetimeFormat));
            }

            // 尝试格式化当前时间，校验格式是否合法
            try
            {
                DateTime.Now.ToString(datetimeFormat);
            }
            catch (FormatException)
            {
                throw new ArgumentException("时间格式无法格式化", nameof(datetimeFormat));
            }

            lock (LockObj)
            {
                _logNameDatetimeFormat = datetimeFormat;
            }

            return this;
        }

        /// <summary>
        /// 设置日志文件扩展名
        /// </summary>
        /// <param name="expandedName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public ILogger SetFileExpandedName(string expandedName)
        {
            if (expandedName.IsEmpty())
            {
                throw new ArgumentException("扩展名不能为空", nameof(expandedName));
            }

            lock (LockObj)
            {
                _logExpandedName = expandedName.StartsWith(".") ? expandedName : "." + expandedName;
            }

            return this;
        }

        /// <summary>
        /// 设置是否按日志等级分文件
        /// </summary>
        /// <param name="separate">是否按等级分文件</param>
        /// <returns></returns>
        public ILogger SetSeparateByLogLevel(bool separate)
        {
            lock (LockObj)
            {
                _separateByLogLevel = separate;
            }

            return this;
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message">日志内容</param>
        [Obsolete("请使用 Info() 方法替代。")]
        public void Write(string message)
        {
            Info(message);
        }

        /// <summary>
        /// 写入消息日志
        /// </summary>
        /// <param name="message">日志内容</param>
        public void Info(string message)
        {
            WriteInner(LogLevel.Info, message);
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="ex">异常信息</param>
        public void Error(string message, Exception ex = null)
        {
            if (ex != null)
            {
                message = $"{message}{Environment.NewLine}Exception: {ex.Message}{Environment.NewLine}StackTrace: {ex.StackTrace}";
            }
            WriteInner(LogLevel.Error, message);
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="level">消息级别</param>
        /// <param name="message">日志内容</param>
        private void WriteInner(LogLevel level, string message)
        {
            try
            {
                lock (LockObj)
                {
                    if (!Directory.Exists(_logDirectory))
                    {
                        Directory.CreateDirectory(_logDirectory);
                    }

                    DateTime now = DateTime.Now;
                    string prefix = _separateByLogLevel ? level.ToString().ToLower() : "all";
                    string fileName = $"{prefix}_{now.ToString(_logNameDatetimeFormat)}{_logExpandedName}";
                    string path = Path.Combine(_logDirectory, fileName);

                    using (var sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                    {
                        sw.Write($"{now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {message}{Environment.NewLine}");
                        sw.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                OnLogWriteException?.Invoke(ex);
            }
        }
    }
}