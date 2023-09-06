using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests
{
    [TestClass()]
    public class CommandLineArgsHelperTests
    {
        private const string ArgsString = "-type net -value ip port";
        private string[] ArgsArray => ArgsString.Split(' ');

        private static IEnumerable<object[]> CommandLineArgs
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        "-type",
                        true,
                        new List<string>(){ "net" }
                    },
                    new object[]
                    {
                        "-test",
                        false,
                        null
                    },
                    new object[]
                    {
                        "-value",
                        true,
                        new List<string>{ "ip", "port" }
                    }
                };
            }
        }

        [TestMethod()]
        [DataRow("-type", true)]
        [DataRow("-test", false)]
        public void HasCommandTest(string key, bool isExist)
        {
            var stringCommand = new CommandLineArgsHelper(ArgsString);
            Assert.IsTrue(stringCommand.HasCommand(key) == isExist);
            var arrayCommand = new CommandLineArgsHelper(ArgsArray);
            Assert.IsTrue(arrayCommand.HasCommand(key) == isExist);
        }

        [TestMethod()]
        [DynamicData(nameof(CommandLineArgs))]
        public void GetCommandValueTest(string key, bool isExist, List<string> value)
        {
            var stringCommand = new CommandLineArgsHelper(ArgsString);
            var result = stringCommand.GetCommandValue(key);
            if (value == null)
            {
                Assert.IsTrue(result == value);
            }
            else
            {
                Assert.IsTrue(result.SequenceEqual(value));
            }

            var arrayCommand = new CommandLineArgsHelper(ArgsArray);
            result = arrayCommand.GetCommandValue(key);
            if (value == null)
            {
                Assert.IsTrue(result == value);
            }
            else
            {
                Assert.IsTrue(result.SequenceEqual(value));
            }
        }

        [TestMethod()]
        [DynamicData(nameof(CommandLineArgs))]
        public void TryGetCommandValueTest(string key, bool isExist, List<string> value)
        {
            var stringCommand = new CommandLineArgsHelper(ArgsString);
            List<string> result;
            var isOk = stringCommand.TryGetCommandValue(key, out result);
            Assert.IsTrue(isOk == isExist);
            if (isOk)
            {
                Assert.IsTrue(result.SequenceEqual(value));
            }

            var arrayCommand = new CommandLineArgsHelper(ArgsArray);
            isOk = arrayCommand.TryGetCommandValue(key, out result);
            Assert.IsTrue(isOk == isExist);
            if (isOk)
            {
                Assert.IsTrue(result.SequenceEqual(value));
            }
        }
    }
}