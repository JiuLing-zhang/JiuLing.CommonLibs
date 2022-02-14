using System;

namespace JiuLing.CommonLibs.ExtensionAttributes
{
    /// <summary>
    /// 描述特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DescriptionAttribute : Attribute
    {
        private readonly string _description;
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="description"></param>
        public DescriptionAttribute(string description)
        {
            _description = description;
        }
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return _description;
        }
    }
}
