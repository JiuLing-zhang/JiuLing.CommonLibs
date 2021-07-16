using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        /// <returns>如果没有匹配到任何项，返回null,否则返回第一个</returns>
        public string GetFirst(string input, string pattern)
        {
            MatchCollection mc = Regex.Matches(input, pattern);
            if (mc.Count == 0)
            {
                return null;
            }
            return mc[0].Value;
        }

        /// <summary>
        /// 根据正则表达式获取输入字符串中的第一个匹配项
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <returns>如果没有匹配到任何项，返回string.Empty,否则返回第一个</returns>
        public string GetFirstOrDefault(string input, string pattern)
        {
            string result = GetFirst(input, pattern);
            return result ?? string.Empty;
        }

        /// <summary>
        /// 根据正则表达式获取输入字符串中的所有匹配项
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <returns>如果没有匹配到任何项，返回null,否则返回匹配到的所有项</returns>
        public List<string> GetAll(string input, string pattern)
        {
            MatchCollection mc = Regex.Matches(input, pattern);
            if (mc.Count == 0)
            {
                return null;
            }

            var result = new List<string>();
            foreach (Match item in mc)
            {
                result.Add(item.Value);
            }
            return result;
        }
    }
}
