using System;
using System.Collections.Generic;
using System.Linq;

namespace JiuLing.CommonLibs.Collections
{
    /// <summary>
    /// Dictionary对象对比工具
    /// </summary>
    /// <typeparam name="TKey">Dictionary的键类型</typeparam>
    /// <typeparam name="TValue">Dictionary的值类型</typeparam>
    public class DictionaryComparer<TKey, TValue> : IEqualityComparer<Dictionary<TKey, TValue>>
    {
        private readonly IEqualityComparer<TValue> _valueComparer;
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="valueComparer"></param>
        public DictionaryComparer(IEqualityComparer<TValue> valueComparer = null)
        {
            this._valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;
        }
        /// <summary>
        /// 对象比较
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(Dictionary<TKey, TValue> x, Dictionary<TKey, TValue> y)
        {
            //判断空对象
            if (x == null || y == null)
            {
                return (x == null && y == null);
            }

            if (x.Count != y.Count)
            {
                return false;
            }

            //取差集对比key
            if (x.Keys.Except(y.Keys).Any())
            {
                return false;
            }
            if (y.Keys.Except(x.Keys).Any())
            {
                return false;
            }

            foreach (var pair in x)
            {
                if (!_valueComparer.Equals(pair.Value, y[pair.Key]))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// GetHashCode（未实现）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetHashCode(Dictionary<TKey, TValue> obj)
        {
            throw new NotImplementedException();
        }
    }
}
