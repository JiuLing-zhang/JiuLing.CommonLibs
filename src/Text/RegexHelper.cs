using System.Text.RegularExpressions;

namespace JiuLing.CommonLibs.Text
{
    /// <summary>
    /// 正则表达式工具类
    /// </summary>
    public class RegexHelper
    {
        /// <summary>
        /// 指示所指定的正则表达式在指定的输入字符串中是否找到了匹配项。。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则为 false。</returns>
        public bool IsMatch(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }
    }
}
