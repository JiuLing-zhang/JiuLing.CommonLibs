using System.Collections.Generic;
using System.Text.RegularExpressions;
using JiuLing.CommonLibs.ExtensionMethods;

namespace JiuLing.CommonLibs.Text
{
    /// <summary>
    /// 正则表达式工具类
    /// </summary>
    public class RegexHelper
    {
        /// <summary>
        /// 指示所指定的正则表达式在指定的输入字符串中是否找到了匹配项。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则为 false。</returns>
        public bool IsMatch(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// 根据正则表达式获取输入字符串中的第一个匹配项
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <returns>如果没有匹配到任何项，success=false,否则result返回第一个匹配项</returns>
        public (bool success, string result) GetFirst(string input, string pattern)
        {
            MatchCollection mc = Regex.Matches(input, pattern);
            if (mc.Count == 0)
            {
                return (false, string.Empty);
            }
            return (true, mc[0].Value);
        }

        /// <summary>
        /// 根据正则表达式获取输入字符串中的所有匹配项
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <returns>如果没有匹配到任何项，返回一个空列表,否则返回匹配到的所有项</returns>
        public List<string> GetAll(string input, string pattern)
        {
            var result = new List<string>();
            MatchCollection mc = Regex.Matches(input, pattern);
            if (mc.Count == 0)
            {
                return result;
            }
            foreach (Match item in mc)
            {
                result.Add(item.Value);
            }
            return result;
        }

        /// <summary>
        /// 根据正则表达式获取输入字符串中的所有匹配项
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <returns>如果没有匹配到任何项，success=false,否则result返回匹配到的唯一分组</returns>
        public (bool success, string result) GetOneGroupInFirstMatch(string input, string pattern)
        {
            MatchCollection mc = Regex.Matches(input, pattern);
            if (mc.Count == 0)
            {
                return (false, string.Empty);
            }

            //该方法只匹配唯一的分组，所以这里强制校验下匹配到的结果是否正确
            if (mc[0].Groups.Count != 2)
            {
                return (false, string.Empty);
            }
            return (true, mc[0].Groups[1].Value);
        }

        /// <summary>
        /// 根据正则表达式获取输入字符串中的所有匹配项
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <param name="groupNames">要查找的分组列表。</param>
        /// <returns>如果没有匹配到任何项，success=false,否则result返回一个dynamic对象，其属性为传入的分组名</returns>
        public (bool success, dynamic result) GetMultiGroupInFirstMatch(string input, string pattern, List<string> groupNames)
        {
            if (groupNames == null || groupNames.Count == 0)
            {
                return (false, string.Empty);
            }
            MatchCollection mc = Regex.Matches(input, pattern);
            if (mc.Count == 0)
            {
                return (false, string.Empty);
            }

            //匹配到的分组数量与需要查找的分组数量不一致
            if (mc[0].Groups.Count != groupNames.Count + 1)
            {
                return (false, string.Empty);
            }

            dynamic obj = new System.Dynamic.ExpandoObject();
            foreach (string groupName in groupNames)
            {
                ((IDictionary<string, object>)obj).Add(groupName, mc[0].Groups[groupName].Value);
            }
            return (true, obj);
        }
    }
}
