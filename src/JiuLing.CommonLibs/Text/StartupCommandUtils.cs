using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JiuLing.CommonLibs.Text
{
    /// <summary>
    /// 启动参数解析工具类
    /// </summary>
    public static class StartupCommandUtils
    {
        private static string _input;
        private static Hashtable _result;
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
            _result = new Hashtable();
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
                if (_result.ContainsKey(commandKey))
                {
                    throw new Exception("参数重复");
                }
                _result.Add(commandKey, argList);
            }
        }
        /// <summary>
        /// 是否包含指定的参数
        /// </summary>
        /// <param name="key">参数名，例如：-t</param>
        public static bool HasCommand(string key)
        {
            return _result.ContainsKey(key);
        }
        /// <summary>
        /// 获取指定参数的参数值
        /// </summary>
        /// <param name="key">参数名，例如：-t</param>
        /// <returns>参数不存在时返回null</returns>
        public static IList<string> GetCommandValue(string key)
        {
            if (!_result.ContainsKey(key))
            {
                return default;
            }
            return _result[key] as List<string>;
        }
        /// <summary>
        /// 尝试获取指定参数的参数值
        /// </summary>
        /// <param name="key">参数名，例如：-t</param>
        /// <param name="commandValue">获取到的参数值，不存在时返回null</param>
        /// <returns>参数是否存在</returns>
        public static bool TryGetCommandValue(string key, out IList<string> commandValue)
        {
            if (!_result.ContainsKey(key))
            {
                commandValue = default;
                return false;
            }

            if (!(_result[key] is List<string> value))
            {
                commandValue = default;
                return false;
            }
            commandValue = value;
            return true;
        }
    }
}
