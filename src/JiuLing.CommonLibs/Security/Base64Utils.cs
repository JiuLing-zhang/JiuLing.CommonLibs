using System;
using System.Text;

namespace JiuLing.CommonLibs.Security
{
    /// <summary>
    /// Base64的工具类
    /// </summary>
    public static class Base64Utils
    {
        /// <summary>
        /// 编码格式
        /// </summary>
        public static Encoding DefaultEncoding = Encoding.UTF8;

        /// <summary>
        /// 根据Base64值返回原始字符串
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>原始字符串</returns>
        public static string Base64ToString(string input)
        {
            byte[] bytes = Convert.FromBase64String(input);
            return DefaultEncoding.GetString(bytes);
        }

        /// <summary>
        /// 获取字符串的Base64
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>字符串的Base64值</returns>
        public static string StringToBase64(string input)
        {
            byte[] bytes = DefaultEncoding.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }
    }
}
