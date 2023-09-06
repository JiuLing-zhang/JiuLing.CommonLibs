using System;
using System.ComponentModel;
using System.Reflection;

namespace JiuLing.CommonLibs.ExtensionMethods
{
    /// <summary>
    /// 枚举的扩展方法
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举的描述值
        /// </summary>
        public static string GetDescription(this Enum input)
        {
            Type type = input.GetType();

            FieldInfo field = type.GetField(input.ToString());

            if (field == null)
            {
                return input.ToString();
            }
            if (!field.IsDefined(typeof(DescriptionAttribute), true))
            {
                return input.ToString();
            }
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (attribute == null)
            {
                throw new ArgumentNullException(nameof(DescriptionAttribute), "未配置描述值");
            }
            return attribute.Description;
        }
    }
}
