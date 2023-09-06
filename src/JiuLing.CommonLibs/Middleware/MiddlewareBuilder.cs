using System.Collections.Generic;
using System.Threading.Tasks;

namespace JiuLing.CommonLibs.Middleware
{
    /// <summary>
    /// 中间件构造器
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class MiddlewareBuilder<TContext> : IMiddlewareBuilder<TContext> where TContext : class
    {
        private readonly IList<IMiddleware<TContext>> _components = new List<IMiddleware<TContext>>();

        /// <summary>
        /// 构造中间件
        /// </summary>
        /// <param name="middleware">具体的中间件</param>
        /// <returns></returns>
        public IMiddlewareBuilder<TContext> Use(IMiddleware<TContext> middleware)
        {
            _components.Add(middleware);
            return this;
        }

        /// <summary>
        /// 执行所有中间件
        /// </summary>
        /// <param name="context">中间件执行前，初始化的上下文</param>
        /// <returns>返回中间件执行完成后的上下文结果</returns>
        public async Task<TContext> ExecuteAsync(TContext context)
        {
            foreach (var component in _components)
            {
                await component.InvokeAsync(context);
                if (!component.IsExecuteNext)
                {
                    break;
                }
            }
            return context;
        }
    }
}
