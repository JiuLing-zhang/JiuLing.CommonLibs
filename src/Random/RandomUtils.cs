using System.Collections.Generic;

namespace JiuLing.CommonLibs.Random
{
    /// <summary>
    /// 随机数帮助类
    /// </summary>
    public class RandomUtils
    {
        private static readonly System.Random MyRandom = new();

        /// <summary>
        /// 获取一个指定长度的随机数
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GetOneByLength(int length = 10)
        {
            string val = "";
            for (int i = 0; i < length; i++)
            {
                val = $"{val}{MyRandom.Next(1, 10)}";
            }
            return val;
        }
        /// <summary>
        /// 随机获取列表中的一个元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T GetOneFromList<T>(IList<T> input)
        {
            if (input == null || input.Count == 0)
            {
                return default(T);
            }

            var index = MyRandom.Next(0, input.Count);
            return input[index];
        }
    }
}
