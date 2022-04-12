#if NET6_0_OR_GREATER
using System.Text.Json;

namespace JiuLing.CommonLibs.ExtensionMethods
{
    public static class JsonExtension
    {
        public static JsonSerializerOptions DefaultOptions { get; set; } = new JsonSerializerOptions();

        public static T? ToObject<T>(this string json)
        {
            return ToObject<T>(json, DefaultOptions);
        }

        public static T? ToObject<T>(this string json, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(json, options);
        }

        public static string ToJson(this object value)
        {
            return ToJson(value, DefaultOptions);
        }

        public static string ToJson(this object value, JsonSerializerOptions options)
        {
            return JsonSerializer.Serialize(value, options);
        }
    }
}
#endif
