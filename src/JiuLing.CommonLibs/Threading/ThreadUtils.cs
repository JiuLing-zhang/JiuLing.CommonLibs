using System.Threading;

namespace JiuLing.CommonLibs.Threading
{
    /// <summary>
    /// 线程相关的帮助类
    /// </summary>
    public class ThreadUtils
    {
        private static readonly System.Random MyRandom = new System.Random();

        /// <summary>
        /// 将当前线程挂起指定的秒数。
        /// </summary>
        /// <param name="minValue">要挂起的毫秒随机数的下界（随机数可取该下界值）</param>
        /// <param name="maxValue">要挂起的毫秒随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        public static void SleepRandomSecond(int minValue, int maxValue)
        {
            Thread.Sleep(MyRandom.Next(minValue, maxValue) * 1000);
        }

        /// <summary>
        /// 将当前线程挂起指定的毫秒数。
        /// </summary>
        /// <param name="minValue">要挂起的毫秒随机数的下界（随机数可取该下界值）</param>
        /// <param name="maxValue">要挂起的毫秒随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        public static void SleepRandomMillisecond(int minValue, int maxValue)
        {
            Thread.Sleep(MyRandom.Next(minValue, maxValue));
        }
    }
}
