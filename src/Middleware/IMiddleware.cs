using System.Threading.Tasks;

namespace JiuLing.CommonLibs.Middleware
{
    /// <summary>
    /// 用来实现中间件的接口定义
    /// </summary>
    /// <typeparam name="TContext">中间件调度过程中上下文的参数类型</typeparam>
    public interface IMiddleware<TContext> where TContext : class
    {
        /// <summary>
        /// 是否继续向下调度
        /// </summary>
        bool IsExecuteNext { get; set; }

        /// <summary>
        /// 中间件内容的具体异步实现
        /// </summary>
        /// <param name="context">中间件上下文对象</param>
        /// <returns></returns>
        Task InvokeAsync(TContext context);
    }
}
