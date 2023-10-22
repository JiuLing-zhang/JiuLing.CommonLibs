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
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string input) => string.IsNullOrEmpty(input);
        /// <summary>
        /// Trim 后是否为空
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsTrimEmpty(this string input) => string.IsNullOrEmpty(input.Trim());
        /// <summary>
        /// 是否不为空
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string input) => !string.IsNullOrEmpty(input);
        /// <summary>
        /// Trim 后是否不为空
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNotTrimEmpty(this string input) => !string.IsNullOrEmpty(input.Trim());
        /// <summary>
        /// 转换为 Uri 对象
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Uri ToUri(this string input) => new Uri(input);
    }
}
