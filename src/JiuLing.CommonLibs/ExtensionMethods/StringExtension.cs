﻿using System;
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

        /// <summary>
        /// 超过长度自动截取
        /// </summary>
        /// <param name="str"></param>
        /// <param name="maxLength">最大长度</param>
        /// <param name="ellipsis">截取后末尾拼接的字符串</param>
        /// <returns></returns>
        public static string Truncate(this string str, int maxLength = 20, string ellipsis = "...")
        {
            if (str.IsEmpty() || str.Length <= maxLength)
            {
                return str;
            }

            return str.Substring(0, maxLength) + ellipsis;
        }

        /// <summary>
        /// 字符串转大写或小写
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isToUpper">大写/小写</param>
        /// <returns></returns>
        public static string ToUpperOrLower(this string value, bool isToUpper)
        {
            if (isToUpper)
            {
                return value.ToUpper();
            }
            else
            {
                return value.ToLower();
            }
        }

        /// <summary>
        /// 姓名掩码 2位（含）之内：首位*；其余：首位**末位
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MaskName(this string value)
        {
            if (value.IsEmpty())
            {
                return string.Empty;
            }

            if (value.Length <= 2)
            {
                return value.Substring(0, 1) + "*";
            }

            return value.Substring(0, 1) + "**" + value.Substring(value.Length - 1, 1);
        }
    }
}
