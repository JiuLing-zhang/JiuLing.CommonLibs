using System.Threading.Tasks;

namespace JiuLing.CommonLibs.Middleware
{
    /// <summary>
    /// 定义中间件构造器的接口
    /// </summary>
    /// <typeparam name="TContext">中间件调度过程中上下文的参数类型</typeparam>
    public interface IMiddlewareBuilder<TContext> where TContext : class
    {
        /// <summary>
        /// 构造中间件
        /// </summary>
        /// <param name="middleware">具体的中间件</param>
        /// <returns></returns>
        IMiddlewareBuilder<TContext> Use(IMiddleware<TContext> middleware);

        /// <summary>
        /// 异步执行所有中间件
        /// </summary>
        /// <param name="context">中间件执行前，初始化的上下文</param>
        /// <returns>返回中间件执行完成后的上下文结果</returns>
        Task<TContext> ExecuteAsync(TContext context);
    }
}
