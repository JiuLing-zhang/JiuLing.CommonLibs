using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JiuLing.CommonLibs.Security
{
    /// <summary>
    /// SHA256 的帮助类
    /// </summary>
    public class SHA256Utils
    {
        /// <summary>
        /// 编码格式
        /// </summary>
        public static Encoding DefaultEncoding = Encoding.UTF8;

        /// <summary>
        /// 计算文件的哈希值（小写）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>返回文件的哈希值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetFileValueToLower(string fileName)
        {
            return GetFileValueToUpper(fileName).ToLower();
        }

        /// <summary>
        /// 计算文件的哈希值（大写）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>返回文件的哈希值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetFileValueToUpper(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }

            using (var file = new FileStream(fileName, FileMode.Open))
            {
                return GetFileValueToUpper(file);
            }
        }

        /// <summary>
        /// 计算文件的哈希值（小写）
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <returns>返回文件的哈希值</returns>
        public static string GetFileValueToLower(Stream stream)
        {
            return GetFileValueToUpper(stream).ToLower();
        }

        /// <summary>
        /// 计算文件的哈希值（大写）
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <returns>返回文件的哈希值</returns>
        public static string GetFileValueToUpper(Stream stream)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "");
        }

        /// <summary>
        /// 计算字符串的哈希值（小写）
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>返回字符串的哈希值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetStringValueToLower(string input)
        {
            return GetStringValueToUpper(input).ToLower();
        }

        /// <summary>
        /// 计算字符串的哈希值（大写）
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>返回字符串的哈希值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetStringValueToUpper(string input)
        {
            byte[] inputBytes = DefaultEncoding.GetBytes(input);
            SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
}
