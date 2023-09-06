using System;

namespace JiuLing.CommonLibs.Middleware
{
    /// <summary>
    /// 中间件基础组件
    /// </summary>
    public class Middleware
    {
        /// <summary>
        /// 创建中间件构造器
        /// </summary>
        /// <typeparam name="TContext">中间件调度过程中上下文的参数类型</typeparam>
        /// <returns></returns>
        public static MiddlewareBuilder<TContext> CreateBuilder<TContext>() where TContext : class
        {
            if (typeof(TContext) == Type.GetType("System.String"))
            {
                throw new ArgumentException("上下文仅支持引用类型");
            }
            return new MiddlewareBuilder<TContext>();
        }
    }
}
