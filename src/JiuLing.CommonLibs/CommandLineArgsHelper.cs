using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JiuLing.CommonLibs
{
    /// <summary>
    /// 命令行参数解析工具
    /// </summary>
    public class CommandLineArgsHelper
    {
        private readonly ConcurrentDictionary<string, List<string>> _args = new ConcurrentDictionary<string, List<string>>();

        /// <summary>
        /// 使用 Environment.GetCommandLineArgs() 初始化参数
        /// </summary>
        public CommandLineArgsHelper()
        {
            BuildArgs(string.Join(" ", Environment.GetCommandLineArgs()));
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="args">参数集合</param>
        public CommandLineArgsHelper(string[] args)
        {
            BuildArgs(string.Join(" ", args));
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="args">参数</param>
        public CommandLineArgsHelper(string args)
        {
            BuildArgs(args);
        }

        private void BuildArgs(string args)
        {
            string pattern = @"(?<=(\s|^))-.*?(?=(?<=(\s|^))-|$)";
            MatchCollection mc = Regex.Matches(args, pattern);
            if (mc.Count == 0)
            {
                return;
            }

            foreach (Match m in mc)
            {
                string argPart = m.Value.Trim();
                var argList = new List<string>(argPart.Split(' '));

                string commandKey = argList[0].Trim();
                argList.RemoveAt(0);

                if (!_args.TryAdd(commandKey, argList))
                {
                    throw new ArgumentException($"参数初始化失败：{commandKey}");
                }
            }
        }

        /// <summary>
        /// 是否包含指定参数
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns></returns>
        public bool HasCommand(string key)
        {
            return _args.ContainsKey(key);
        }

        /// <summary>
        /// 获取指定的参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns></returns>
        public List<string> GetCommandValue(string key)
        {
            _args.TryGetValue(key, out var value);
            return value;
        }

        /// <summary>
        /// 尝试获取指定的参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public bool TryGetCommandValue(string key, out List<string> value)
        {
            var result = _args.TryGetValue(key, out value);
            return result;
        }
    }
}
