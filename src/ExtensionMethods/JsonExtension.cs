#if NET6_0_OR_GREATER
using System.Text.Json;

namespace JiuLing.CommonLibs.ExtensionMethods
{
    /// <summary>
    /// Json扩展工具
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// 默认的 JsonSerializerOptions
        /// </summary>
        public static JsonSerializerOptions DefaultOptions { get; set; } = new JsonSerializerOptions();

        /// <summary>
        /// 字符串转对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="json">输入字符串</param>
        /// <returns>转换后的 Json 对象</returns>
        public static T? ToObject<T>(this string json)
        {
            return ToObject<T>(json, DefaultOptions);
        }

        /// <summary>
        /// 字符串转对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="json">输入字符串</param>
        /// <param name="options">JsonSerializerOptions</param>
        /// <returns>转换后的 Json 对象</returns>
        public static T? ToObject<T>(this string json, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(json, options);
        }

        /// <summary>
        /// 对象转字符串
        /// </summary>
        /// <param name="value">Json 对象</param>
        /// <returns>转换后的字符串</returns>
        public static string ToJson(this object value)
        {
            return ToJson(value, DefaultOptions);
        }

        /// <summary>
        /// 对象转字符串
        /// </summary>
        /// <param name="value">Json 对象</param>
        /// <param name="options">JsonSerializerOptions</param>
        /// <returns>转换后的字符串</returns>
        public static string ToJson(this object value, JsonSerializerOptions options)
        {
            return JsonSerializer.Serialize(value, options);
        }
    }
}
#endif
