using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JiuLing.CommonLibs.Security
{
    /// <summary>
    /// MD5的帮助类
    /// </summary>
    public static class MD5Utils
    {
        /// <summary>
        /// 编码格式
        /// </summary>
        public static Encoding DefaultEncoding = Encoding.UTF8;

        /// <summary>
        /// 计算字符串的32位MD5值（小写）
        /// </summary>
        /// <param name="input">要计算的字符串</param>
        /// <returns>返回字符串的MD5值</returns>
        public static string GetStringValueToLower(string input)
        {
            return GetStringValueToUpper(input).ToLower();
        }

        /// <summary>
        /// 计算字符串的32位MD5值（大写）
        /// </summary>
        /// <param name="input">要计算的字符串</param>
        /// <returns>返回字符串的MD5值</returns>
        public static string GetStringValueToUpper(string input)
        {
            var byteValue = DefaultEncoding.GetBytes(input);
            using (var md5Instance = MD5.Create())
            {
                var byteHash = md5Instance.ComputeHash(byteValue);
                string tmpValue = "";
                for (int i = 0; i < byteHash.Length; i++)
                {
                    tmpValue += byteHash[i].ToString("X").PadLeft(2, '0');
                }
                return tmpValue;
            }
        }

        /// <summary>
        /// 计算文件的MD5（小写）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetFileValueToLower(string fileName)
        {
            return GetFileValueToUpper(fileName).ToLower();
        }

        /// <summary>
        /// 计算文件的MD5（大写）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetFileValueToUpper(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }

            using (var stream = File.OpenRead(fileName))
            {
                return GetFileValueToUpper(stream);
            }
        }

        /// <summary>
        /// 计算文件的MD5（小写）
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <returns></returns>
        public static string GetFileValueToLower(Stream stream)
        {
            return GetFileValueToUpper(stream).ToLower();
        }

        /// <summary>
        /// 计算文件的MD5（大写）
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <returns></returns>
        public static string GetFileValueToUpper(Stream stream)
        {
            stream.Position = 0;
            using (var md5Instance = MD5.Create())
            {
                var hashResult = md5Instance.ComputeHash(stream);
                return BitConverter.ToString(hashResult).Replace("-", "");
            }
        }
    }
}
