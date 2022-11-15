using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JiuLing.CommonLibs.Threading.Tests
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
        public void LeaveTest()
        {
            var spinLock = new SpinLock();

            int _count = 0;
            var tasks = new List<Task>();
            for (int i = 0; i < 2000; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    spinLock.Enter();
                    _count = _count + 1;
                    spinLock.Leave();
                }));
            }
            Task.WaitAll(tasks.ToArray());
            Assert.AreEqual(tasks.Count, _count);
        }
    }
}