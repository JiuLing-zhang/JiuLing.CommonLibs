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
        public static string GetFileLowerValue(string path)
        {
            return GetFileUpperValue(path).ToLower();
        }

        /// <summary>
        /// 计算文件的SHA1值（大写）
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回文件的SHA1值</returns>
        public static string GetFileUpperValue(string path)
        {
            var file = new FileStream(path, FileMode.Open);
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
