using JiuLing.CommonLibs.ExtensionMethods;
using System;
using System.IO;

namespace JiuLing.CommonLibs.Log
{
    /// <summary>
    /// 文本日志
    /// </summary>
    public class TextLogger : ILogger
    {
        private string _logDirectory;
        private string _logNameDatetimeFormat;
        private string _logExpandedName;
        /// <summary>
        /// 实例化
        /// </summary>
        public TextLogger()
        {
            _logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
            _logNameDatetimeFormat = "yyyy-MM-dd";
            _logExpandedName = ".log";
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
                throw new ArgumentException(nameof(path));
            }

            _logDirectory = path;
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
                throw new ArgumentException(nameof(datetimeFormat));
            }
            _logNameDatetimeFormat = datetimeFormat;
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
                throw new ArgumentException(nameof(expandedName));
            }
            _logExpandedName = expandedName;
            return this;
        }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message)
        {
            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }

            DateTime now = DateTime.Now;
            string fileName = $"{now.ToString(_logNameDatetimeFormat)}{_logExpandedName}";
            string path = Path.Combine(_logDirectory, fileName);

            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
            {
                sw.Write($"{now:yyyy-MM-dd HH:mm:ss.fff} {message}{Environment.NewLine}");
                sw.Flush();
            }
        }
    }
}
