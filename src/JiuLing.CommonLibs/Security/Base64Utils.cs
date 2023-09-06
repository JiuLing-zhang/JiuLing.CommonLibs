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
        [Obsolete("该方法将在1.6版本中删除，请改用StringToBase64方法。")]
        public static string GetStringValue(string input)
        {
            return StringToBase64(input);
        }

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
