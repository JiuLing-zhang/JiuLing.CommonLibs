using System;

namespace JiuLing.CommonLibs.ExtensionAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DescriptionAttribute : Attribute
    {
        private readonly string _description;
        public DescriptionAttribute(string description)
        {
            _description = description;
        }

        public string GetDescription()
        {
            return _description;
        }
    }
}
