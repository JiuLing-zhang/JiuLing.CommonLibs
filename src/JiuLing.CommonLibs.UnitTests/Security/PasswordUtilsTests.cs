#if NET6_0_OR_GREATER

using JiuLing.CommonLibs.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.Security
{
    [TestClass()]
    public class PasswordUtilsTests
    {
        [TestMethod()]
        public void HashPassword_ShouldReturnDifferentHashesForSamePassword()
        {
            string password = "password";

            string hash1 = PasswordUtils.HashPassword(password);
            string hash2 = PasswordUtils.HashPassword(password);

            Assert.AreNotEqual(hash1, hash2); // 随机 salt，哈希必须不同
        }

        [TestMethod()]
        public void VerifyPassword_ShouldReturnTrueForCorrectPassword()
        {
            string password = "password";
            string hash = PasswordUtils.HashPassword(password);

            bool result = PasswordUtils.VerifyPassword(password, hash);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void VerifyPassword_ShouldReturnFalseForIncorrectPassword()
        {
            string password = "password";
            string hash = PasswordUtils.HashPassword(password);

            bool result = PasswordUtils.VerifyPassword("WrongPassword", hash);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void VerifyPassword_ShouldFailForInvalidBase64()
        {
            string invalidHash = "not_base64";

            bool result = PasswordUtils.VerifyPassword("password", invalidHash);

            Assert.IsFalse(result);
        }
    }
}

#endif