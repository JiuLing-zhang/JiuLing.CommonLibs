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
        /// 编码格式
        /// </summary>
        public static Encoding DefaultEncoding = Encoding.UTF8;

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

            using (var file = new FileStream(fileName, FileMode.Open))
            {
                return GetFileValueToUpper(file);
            }
        }

        /// <summary>
        /// 计算文件的SHA1值（小写）
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <returns>返回文件的SHA1值</returns>
        public static string GetFileValueToLower(Stream stream)
        {
            return GetFileValueToUpper(stream).ToLower();
        }

        /// <summary>
        /// 计算文件的SHA1值（大写）
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <returns>返回文件的SHA1值</returns>
        public static string GetFileValueToUpper(Stream stream)
        {
            stream.Position = 0;
            var byteHash = SHA1.Create().ComputeHash(stream);

            string tmpValue = "";
            for (int i = 0; i < byteHash.Length; i++)
            {
                tmpValue += byteHash[i].ToString("X").PadLeft(2, '0');
            }
            return tmpValue;
        }

        /// <summary>
        /// 计算字符串的SHA1值（小写）
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>返回字符串的SHA1值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetStringValueToLower(string input)
        {
            return GetStringValueToUpper(input).ToLower();
        }

        /// <summary>
        /// 计算字符串的SHA1值（大写）
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>返回字符串的SHA1值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetStringValueToUpper(string input)
        {
            var buffer = DefaultEncoding.GetBytes(input);//用指定编码转为bytes数组
            var byteHash = SHA1.Create().ComputeHash(buffer);

            string tmpValue = "";
            for (int i = 0; i < byteHash.Length; i++)
            {
                tmpValue += byteHash[i].ToString("X").PadLeft(2, '0');
            }
            return tmpValue;
        }

        /// <summary>
        /// 计算SHA1值（小写）
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <returns>返回字符串的SHA1值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetBytesValueToLower(byte[] buffer)
        {
            return GetBytesValueToUpper(buffer).ToLower();
        }

        /// <summary>
        /// 计算SHA1值（大写）
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <returns>返回字节数组的SHA1值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetBytesValueToUpper(byte[] buffer)
        {
            var byteHash = SHA1.Create().ComputeHash(buffer);

            string tmpValue = "";
            for (int i = 0; i < byteHash.Length; i++)
            {
                tmpValue += byteHash[i].ToString("X").PadLeft(2, '0');
            }
            return tmpValue;
        }
    }
}
