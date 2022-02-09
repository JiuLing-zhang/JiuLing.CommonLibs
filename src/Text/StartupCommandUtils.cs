using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JiuLing.CommonLibs.Text
{
    /// <summary>
    /// 启动参数解析工具类
    /// </summary>
    public class StartupCommandUtils
    {
        private static string _input;
        private static readonly Hashtable Result = new Hashtable();
        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <param name="input">待解析的启动参数</param>
        public static void Initialize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("启动参数不能为空");
            }
            _input = input;
            BuildArgs();
        }

        private static void BuildArgs()
        {
            string pattern = @"(?<=(\s|^))-.*?(?=(?<=(\s|^))-|$)";
            MatchCollection mc = Regex.Matches(_input, pattern);
            if (mc.Count == 0)
            {
                throw new ArgumentException("未匹配到任何启动参数");
            }

            foreach (Match m in mc)
            {
                string argPart = m.Value.Trim();
                var argList = new List<string>(argPart.Split(' '));

                string commandKey = argList[0].Trim();
                argList.RemoveAt(0);
                if (Result.ContainsKey(commandKey))
                {
                    throw new Exception("参数重复");
                }
                Result.Add(commandKey, argList);
            }
        }
        /// <summary>
        /// 是否包含指定的参数
        /// </summary>
        /// <param name="key">参数名，例如：-t</param>
        public static bool HasCommand(string key)
        {
            return Result.ContainsKey(key);
        }
        /// <summary>
        /// 获取指定参数的参数值
        /// </summary>
        /// <param name="key">参数名，例如：-t</param>
        public static IList<string> GetCommandValue(string key)
        {
            if (!Result.ContainsKey(key))
            {
                return default;
            }
            return Result[key] as List<string>;
        }
        /// <summary>
        /// 尝试获取指定参数的参数值
        /// </summary>
        /// <param name="key">参数名，例如：-t</param>
        /// <param name="commandValue">获取到的参数值</param>
        /// <returns></returns>
        public static bool TryGetCommandValue(string key, out IList<string> commandValue)
        {

            if (!Result.ContainsKey(key))
            {
                commandValue = default;
                return false;
            }

            if (!(Result[key] is List<string> value))
            {
                commandValue = default;
                return false;
            }
            commandValue = value;
            return true;
        }
    }
}
