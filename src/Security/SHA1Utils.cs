using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JiuLing.CommonLibs.Security
{
    /// <summary>
    /// SHA1的帮助类
    /// </summary>
    public class SHA1Utils
    {
        /// <summary>
        /// 计算文件的SHA1值（小写）
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回文件的SHA1值</returns>
        [Obsolete("该方法以后会删除，请使用 GetFileValueToLower 替代。")]
        public static string GetFileLowerValue(string path)
        {
            return GetFileValueToLower(path);
        }

        /// <summary>
        /// 计算文件的SHA1值（大写）
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回文件的SHA1值</returns>
        [Obsolete("该方法以后会删除，请使用 GetFileValueToUpper 替代。")]
        public static string GetFileUpperValue(string path)
        {
            return GetFileValueToUpper(path);
        }

        /// <summary>
        /// 计算文件的SHA1值（小写）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>返回文件的SHA1值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetFileValueToLower(string fileName)
        {
            return GetFileValueToUpper(fileName).ToLower();
        }

        /// <summary>
        /// 计算文件的SHA1值（大写）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>返回文件的SHA1值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetFileValueToUpper(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }

            var file = new FileStream(fileName, FileMode.Open);
            var sha1 = new SHA1CryptoServiceProvider();
            var byteHash = sha1.ComputeHash(file);
            file.Close();

            string tmpValue = "";
            for (int i = 0; i < byteHash.Length; i++)
            {
                tmpValue += byteHash[i].ToString("X").PadLeft(2, '0');
            }
            return tmpValue;
        }
    }
}
