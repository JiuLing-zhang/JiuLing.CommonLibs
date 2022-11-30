using JiuLing.CommonLibs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using SpinLock = JiuLing.CommonLibs.Threading.SpinLock;

namespace JiuLing.CommonLibs
{
    /// <summary>
    /// 一个线程安全的临时 Id 生成器
    /// </summary>
    public class TempIdGenerator
    {
        private static readonly System.Random MyRandom = new System.Random();
        private readonly SpinLock _spinLock = new SpinLock();
        private readonly List<TempId> _ids;

        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly int _counter;
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="length">要生成的 ID 长度(仅支持长度为2-6位)</param>
        public TempIdGenerator(int length)
        {
            if (length < 2 || length > 6)
            {
                throw new ArgumentException("不支持的长度定义");
            }
            var minValue = "1".PadRight(length, '0');
            var maxValue = $"{minValue}0";

            _minValue = Convert.ToInt32(minValue);
            _maxValue = Convert.ToInt32(maxValue);
            _counter = _maxValue - _minValue;

            _ids = new List<TempId>(_counter);
        }

        /// <summary>
        /// 生成 Id
        /// </summary>
        public int Create(TimeSpan expiration)
        {
            return Create(DateTime.Now.Add(expiration));
        }

        /// <summary>
        /// 生成 Id
        /// </summary>
        public int Create(DateTime expiration)
        {
            _spinLock.Enter();

            ClearExpiredIds();

            if (_counter == _ids.Count)
            {
                _spinLock.Exit();
                return 0;
            }

            int id;
            do
            {
                id = MyRandom.Next(_minValue, _maxValue);
            } while (_ids.Count(x => x.Id == id) > 0);

            _ids.Add(new TempId(id, expiration));

            _spinLock.Exit();
            return id;
        }

        /// <summary>
        /// 清除过期的 Id
        /// </summary>
        private void ClearExpiredIds()
        {
            var time = DateTime.Now;
            _ids.RemoveAll(x => time.Subtract(x.Expiration).TotalSeconds >= 0);
        }
    }
}
