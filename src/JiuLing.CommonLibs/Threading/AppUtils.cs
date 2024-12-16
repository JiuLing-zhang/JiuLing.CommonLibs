using System;
using System.Threading;

namespace JiuLing.CommonLibs.Threading
{
    /// <summary>
    /// 应用程序相关的工具类
    /// </summary>
    public class AppUtils
    {
        private static Mutex _mutex;
        /// <summary>
        /// 程序是否重复运行。        
        /// 此方法在某些环境下可能会判断失效，请谨慎使用，并确保进行充分测试。
        /// </summary>
        /// <param name="appName">app的唯一名称</param>
        /// <param name="globalSession">是否在所有服务器会话中检查唯一</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool IsRerun(string appName, bool globalSession = true)
        {
            if (appName.Contains("\\"))
            {
                throw new ArgumentException("AppName不能包含关键字\\");
            }
            var mutexName = globalSession ? $"Global\\{appName}" : appName;

            try
            {
                _mutex = new Mutex(false, mutexName);

                if (!_mutex.WaitOne(1, true))
                {
                    return true;
                }
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return true;
            }
        }
    }
}
