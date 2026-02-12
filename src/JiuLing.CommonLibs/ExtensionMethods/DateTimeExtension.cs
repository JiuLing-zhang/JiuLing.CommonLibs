using System;
using System.Globalization;

namespace JiuLing.CommonLibs.ExtensionMethods
{
    /// <summary>
    /// 时间扩展方法
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 根据系统语言返回统一友好的日期时间字符串
        /// 中文统一格式: yyyy-MM-dd HH:mm:ss
        /// 英文统一格式: MM/dd/yyyy hh:mm tt
        /// 其他语言使用默认格式 G
        /// </summary>
        public static string ToLocalizedFriendlyString(this DateTime dateTime)
        {
            var culture = CultureInfo.CurrentCulture;
            string language = culture.TwoLetterISOLanguageName;

            string format;
            switch (language)
            {
                case "zh":
                    format = "yyyy-MM-dd HH:mm:ss";
                    break;
                case "en":
                    format = "MM/dd/yyyy hh:mm tt";
                    break;
                default:
                    format = "G";
                    break;
            }

            return ToLocalizedFriendlyString(dateTime, format);
        }

        /// <summary>
        /// 根据系统语言返回统一友好的日期时间字符串
        /// </summary>
        public static string ToLocalizedFriendlyString(this DateTime dateTime, string format)
        {
            var culture = CultureInfo.CurrentCulture;
            return dateTime.ToString(format, culture);
        }
    }
}
