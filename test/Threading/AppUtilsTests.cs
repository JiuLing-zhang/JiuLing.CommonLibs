using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JiuLing.CommonLibs.Threading.Tests
{
    [TestClass()]
    public class AppUtilsTests
    {
        [TestMethod()]
        public void IsRerunTest()
        {
            string appName = "JiuLing.CommonLibs.Test";

            var tasks = new List<Task>();

            bool? result1 = null;
            var task1 = new Task(() =>
            {
                result1 = AppUtils.IsRerun(appName);
            });

            bool? result2 = null;
            var task2 = new Task(() =>
            {
                result2 = AppUtils.IsRerun(appName);
            });

            tasks.Add(task1);
            tasks.Add(task2);

            task1.Start();
            task2.Start();
            Task.WaitAll(tasks.ToArray());

            Assert.IsTrue(result1.HasValue);
            Assert.IsTrue(result2.HasValue);
            Assert.IsTrue(result1 != result2);
        }
    }
}