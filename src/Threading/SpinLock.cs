using System.Threading;

namespace JiuLing.CommonLibs.Threading
{
    /// <summary>
    /// 自旋锁
    /// </summary>
    public class SpinLock
    {
        private int _lockValue;

        /// <summary>
        /// 进入
        /// </summary>
        public void Enter()
        {
            while (true)
            {
                if (Interlocked.Exchange(ref _lockValue, 1) == 0)
                {
                    return;
                }
                //如果有线程正在调用，那么后来的线程就一直在这里“自旋”
            }
        }

        /// <summary>
        /// 离开
        /// </summary>
        public void Leave()
        {
            Interlocked.Exchange(ref _lockValue, 0);
        }
    }
}
