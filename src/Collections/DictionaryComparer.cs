﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace JiuLing.CommonLibs.Collections
{
    public class DictionaryComparer<TKey, TValue> : IEqualityComparer<Dictionary<TKey, TValue>>
    {
        private readonly IEqualityComparer<TValue> _valueComparer;
        public DictionaryComparer(IEqualityComparer<TValue> valueComparer = null)
        {
            this._valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;
        }
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
        public int GetHashCode(Dictionary<TKey, TValue> obj)
        {
            throw new NotImplementedException();
        }
    }
}
