using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JiuLing.CommonLibs.Middleware.Tests
{
    [TestClass()]
    public class MiddlewareBuilderTests
    {
        [TestMethod()]
        public void ExecuteAsyncTest()
        {
            var builder = Middleware.CreateBuilder<List<int>>();
            builder
                .Use(new MiddlewareAsyncTest1())
                .Use(new MiddlewareAsyncTest2())
                .Use(new MiddlewareAsyncTest3());

            var result = builder.ExecuteAsync(new List<int>()).Result;
            Assert.IsTrue(result.Count == 2);
        }
    }

    internal class MiddlewareAsyncTest1 : IMiddleware<List<int>>
    {
        public bool IsExecuteNext { get; set; } = true;
        public Task InvokeAsync(List<int> context)
        {
            context.Add(1);
            return Task.CompletedTask;
        }
    }

    internal class MiddlewareAsyncTest2 : IMiddleware<List<int>>
    {
        public bool IsExecuteNext { get; set; }
        public Task InvokeAsync(List<int> context)
        {
            context.Add(2);
            //不在执行后续中间件
            IsExecuteNext = false;
            return Task.CompletedTask;
        }
    }

    internal class MiddlewareAsyncTest3 : IMiddleware<List<int>>
    {
        public bool IsExecuteNext { get; set; }
        public Task InvokeAsync(List<int> context)
        {
            context.Add(3);
            return Task.CompletedTask;
        }
    }
}