using JiuLing.CommonLibs.ExtensionMethods;
using System;
using System.IO;

namespace JiuLing.CommonLibs.Log
{
    public class TextLogger : ILogger
    {
        private string _logDirectory;
        private string _logNameDatetimeFormat;
        private string _logExpandedName;
        public TextLogger()
        {
            _logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
            _logNameDatetimeFormat = "yyyy-MM-dd";
            _logExpandedName = ".log";
        }
        public ILogger SetLogDirectory(string path)
        {
            if (path.IsEmpty())
            {
                throw new ArgumentException(nameof(path));
            }

            _logDirectory = path;
            return this;
        }

        public ILogger SetFileNameFormat(string datetimeFormat)
        {
            if (datetimeFormat.IsEmpty())
            {
                throw new ArgumentException(nameof(datetimeFormat));
            }
            _logNameDatetimeFormat = datetimeFormat;
            return this;
        }

        public ILogger SetFileExpandedName(string expandedName)
        {
            if (expandedName.IsEmpty())
            {
                throw new ArgumentException(nameof(expandedName));
            }
            _logExpandedName = expandedName;
            return this;
        }

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
