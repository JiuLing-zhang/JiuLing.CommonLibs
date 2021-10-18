using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JiuLing.CommonLibs.Text
{
    /// <summary>
    /// 正则表达式工具类
    /// </summary>
    public class RegexUtils
    {
        /// <summary>
        /// 指示所指定的正则表达式在指定的输入字符串中是否找到了匹配项。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则为 false。</returns>
        public static bool IsMatch(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// 在指定的输入字符串内，使用指定的替换字符串替换与指定正则表达式匹配的所有字符串。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <param name="replacement">替换字符串。</param>
        /// <returns>一个与输入字符串基本相同的新字符串，唯一的差别在于，其中的每个匹配字符串已被替换字符串代替。 如果 pattern 与当前实例不匹配，则此方法返回未更改的当前实例。</returns>
        public static string Replace(string input, string pattern, string replacement)
        {
            return Regex.Replace(input, pattern, replacement);
        }

        /// <summary>
        /// 根据正则表达式获取输入字符串中的第一个匹配项
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <returns>如果没有匹配到任何项，success=false,否则result返回第一个匹配项</returns>
        public static (bool success, string result) GetFirst(string input, string pattern)
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
        public static List<string> GetAll(string input, string pattern)
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
        public static (bool success, string result) GetOneGroupInFirstMatch(string input, string pattern)
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
        /// <returns>如果没有匹配到任何项，success=false,否则result返回一个IDictionary对象，其Key值为Group的名称</returns>
        public static (bool success, IDictionary<string, string> result) GetMultiGroupInFirstMatch(string input, string pattern)
        {
            var checkGroupPattern = @"\?<[a-zA-Z]*>";
            var groups = GetAll(pattern, checkGroupPattern);
            if (groups.Count == 0)
            {
                return (false, null);
            }

            MatchCollection mc = Regex.Matches(input, pattern);
            if (mc.Count == 0)
            {
                return (false, null);
            }

            //匹配到的分组数量与需要查找的分组数量不一致
            if (mc[0].Groups.Count != groups.Count + 1)
            {
                return (false, null);
            }

            IDictionary<string, string> result = new Dictionary<string, string>();
            foreach (string groupName in groups)
            {
                string groupKey = Replace(groupName, "[^a-zA-Z]", "");
                result.Add(groupKey, mc[0].Groups[groupKey].Value);
            }
            return (true, result);
        }
    }
}
