using System;
using System.Text;

namespace JiuLing.CommonLibs.Security
{
    /// <summary>
    /// Base64的工具类
    /// </summary>
    public class Base64Utils
    {
        /// <summary>
        /// 编码格式
        /// </summary>
        public static Encoding DefaultEncoding = Encoding.UTF8;

        /// <summary>
        /// 获取字符串的Base64
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>返回字符串的Base64值</returns>
        public static string GetStringValue(string input)
        {
            byte[] bytes = DefaultEncoding.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }
    }
}
