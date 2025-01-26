using System;

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
        public static bool IsEmpty(this string input, bool checkWhiteSpace = false)
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
        public static bool IsNotEmpty(this string input, bool checkWhiteSpace = false)
        {
            return !input.IsEmpty(checkWhiteSpace);
        }

        /// <summary>
        /// Trim 后是否为空
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Obsolete("请使用 IsEmpty 方法并传递 checkWhiteSpace 参数", true)]
        public static bool IsTrimEmpty(this string input) => string.IsNullOrWhiteSpace(input.Trim());

        /// <summary>
        /// Trim 后是否不为空
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Obsolete("请使用 IsNotEmpty 方法并传递 checkWhiteSpace 参数", true)]
        public static bool IsNotTrimEmpty(this string input) => !string.IsNullOrEmpty(input.Trim());

        /// <summary>
        /// 转换为 Uri 对象
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Uri ToUri(this string input) => new Uri(input);
    }
}
