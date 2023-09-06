using System.Collections.Generic;
using System.Threading.Tasks;
using JiuLing.CommonLibs.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.Threading
{
    [TestClass()]
    public class SpinLockTests
    {
        [TestMethod()]
        public void EnterTest()
        {
            var spinLock = new SpinLock();
            spinLock.Enter();

            var task = Task.Run(() =>
            {
                spinLock.Enter();
            });
            Assert.IsFalse(task.Wait(5000));
        }

        [TestMethod()]
        public void ExitTest()
        {
            var spinLock = new SpinLock();

            int count = 0;
            var tasks = new List<Task>();
            for (int i = 0; i < 2000; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    spinLock.Enter();
                    count = count + 1;
                    spinLock.Exit();
                }));
            }
            Task.WaitAll(tasks.ToArray());
            Assert.AreEqual(tasks.Count, count);
        }
    }
}