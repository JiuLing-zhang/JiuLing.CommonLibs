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
            byte[] hash = SHA256.Create().ComputeHash(stream);
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
            byte[] hashBytes = SHA256.Create().ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

        /// <summary>
        /// 计算SHA256值（小写）
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <returns>返回字符串的SHA1值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetBytesValueToLower(byte[] buffer)
        {
            return GetBytesValueToUpper(buffer).ToLower();
        }

        /// <summary>
        /// 计算SHA256值（大写）
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <returns>返回字节数组的SHA1值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetBytesValueToUpper(byte[] buffer)
        {
            var byteHash = SHA256.Create().ComputeHash(buffer);

            string tmpValue = "";
            for (int i = 0; i < byteHash.Length; i++)
            {
                tmpValue += byteHash[i].ToString("X").PadLeft(2, '0');
            }
            return tmpValue;
        }
    }
}
