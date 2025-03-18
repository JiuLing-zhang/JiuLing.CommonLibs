using System;
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace JiuLing.CommonLibs.ExtensionMethods
{
    /// <summary>
    /// 字符串类型的扩展方法
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="checkWhiteSpace">是否检查空白字符</param>
        /// <returns></returns>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        public static bool IsEmpty([NotNullWhen(false)] this string input, bool checkWhiteSpace = false)
#else
        public static bool IsEmpty(this string input, bool checkWhiteSpace = false)
#endif
        {
            if (checkWhiteSpace)
            {
                return string.IsNullOrWhiteSpace(input);
            }
            return string.IsNullOrEmpty(input);
        }

        /// <summary>
        /// 是否不为空
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="checkWhiteSpace">是否检查空白字符</param>
        /// <returns></returns>

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        public static bool IsNotEmpty([NotNullWhen(true)] this string input, bool checkWhiteSpace = false)
#else
        public static bool IsNotEmpty(this string input, bool checkWhiteSpace = false)
#endif
        {
            return !input.IsEmpty(checkWhiteSpace);
        }

        /// <summary>
        /// 转换为 Uri 对象
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Uri ToUri(this string input) => new Uri(input);
    }
}
