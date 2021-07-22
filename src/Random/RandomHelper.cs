namespace JiuLing.CommonLibs.Random
{
    /// <summary>
    /// 随机数帮助类
    /// </summary>
    public class RandomHelper
    {
        private static readonly System.Random MyRandom = new();

        /// <summary>
        /// 获取一个随机数
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GetOne(int length = 10)
        {
            string val = "";
            for (int i = 0; i < length; i++)
            {
                val = $"{val}{MyRandom.Next(1, 10)}";
            }
            return val;
        }
    }
}
