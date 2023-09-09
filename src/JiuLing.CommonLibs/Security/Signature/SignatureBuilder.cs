using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JiuLing.CommonLibs.Security.Signature
{
    /// <summary>
    /// 签名构建器
    /// </summary>
    public class SignatureBuilder
    {
        /// <summary>
        /// 最终的签名串
        /// </summary>
        private string _signValue;

        /// <summary>
        /// 原始签名串
        /// </summary>
        /// <param name="signValue"></param>
        private SignatureBuilder(string signValue)
        {
            _signValue = signValue;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="parameters">要签名的数据</param>
        /// <returns></returns>
        public static SignatureBuilder Create(IDictionary<string, string> parameters)
        {
            var keyValue = parameters.Select(x => $"{x.Key}={x.Value}").ToList();
            return new SignatureBuilder(string.Join("&", keyValue));
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="parameters">要签名的数据</param>
        /// <returns></returns>
        public static SignatureBuilder Create(string parameters)
        {
            return new SignatureBuilder(parameters);
        }

        /// <summary>
        /// 字典序
        /// </summary>
        /// <returns></returns>
        public SignatureBuilder OrderBy()
        {
            var parameters = _signValue.Split('&').ToList().OrderBy(x => x).ToList();
            _signValue = string.Join("&", parameters);
            return this;
        }

        /// <summary>
        /// 提取参数值
        /// </summary>
        /// <param name="separator">提取后的参数连接符</param>
        /// <returns></returns>
        public SignatureBuilder FetchParameterValue(string separator = "&")
        {
            var parameterKeyValueList = _signValue.Split('&').ToList();
            var parameterValueList = parameterKeyValueList.Select(x => x.Split('=')[1]).ToList();
            _signValue = string.Join(separator, parameterValueList);
            return this;
        }

        /// <summary>
        /// 提取参数名和参数值
        /// </summary>
        /// <param name="separator">提取后的参数连接符</param>
        /// <returns></returns>
        public SignatureBuilder FetchParameterNameAndValue(string separator = "")
        {
            var parameterKeyValueList = _signValue.Split('&').ToList();
            parameterKeyValueList = parameterKeyValueList.Select(x => x.Replace("=", "")).ToList();
            _signValue = string.Join(separator, parameterKeyValueList);
            return this;
        }

        /// <summary>
        /// Base64
        /// </summary>
        /// <returns></returns>
        public SignatureBuilder Base64()
        {
            _signValue = Base64Utils.StringToBase64(_signValue);
            return this;
        }

        /// <summary>
        /// 加前缀
        /// </summary>
        /// <param name="value">前缀值</param>
        /// <returns></returns>
        public SignatureBuilder Prefix(string value)
        {
            _signValue = value + _signValue;
            return this;
        }

        /// <summary>
        /// 加后缀
        /// </summary>
        /// <param name="value">后缀值</param>
        /// <returns></returns>
        public SignatureBuilder Postfix(string value)
        {
            _signValue = _signValue + value;
            return this;
        }

        /// <summary>
        /// MD5
        /// </summary>
        /// <returns></returns>
        public SignatureBuilder MD5()
        {
            _signValue = MD5Utils.GetStringValueToLower(_signValue);
            return this;
        }

        /// <summary>
        /// SHA1
        /// </summary>
        /// <returns></returns>
        public SignatureBuilder SHA1()
        {
            _signValue = SHA1Utils.GetStringValueToLower(_signValue);
            return this;
        }

        /// <summary>
        /// SHA256
        /// </summary>
        /// <returns></returns>
        public SignatureBuilder SHA256()
        {
            _signValue = SHA256Utils.GetStringValueToLower(_signValue);
            return this;
        }

        /// <summary>
        /// 转大写
        /// </summary>
        /// <returns></returns>
        public SignatureBuilder ToUpper()
        {
            _signValue = _signValue.ToUpper();
            return this;
        }

        /// <summary>
        /// 转小写
        /// </summary>
        /// <returns></returns>
        public SignatureBuilder ToLower()
        {
            _signValue = _signValue.ToLower();
            return this;
        }

        /// <summary>
        /// 小写 UrlEncode (1%3d1%262%3d2)
        /// </summary>
        /// <returns></returns>
        public SignatureBuilder UrlEncodeLower()
        {
            _signValue = HttpUtility.UrlEncode(_signValue);
            return this;
        }

        /// <summary>
        /// 大写 UrlEncode (1%3D1%262%3D2)
        /// </summary>
        /// <returns></returns>
        public SignatureBuilder UrlEncodeUpper()
        {
            var sb = new StringBuilder();
            foreach (char s in _signValue)
            {
                var encode = HttpUtility.UrlEncode(s.ToString());
                if (encode.Length > 1)
                {
                    sb.Append(encode.ToUpper());
                }
                else
                {
                    sb.Append(encode);
                }
            }
            _signValue = sb.ToString();
            return this;
        }

        /// <summary>
        /// 获取签名结果
        /// </summary>
        /// <returns></returns>
        public string GetResult()
        {
            return _signValue;
        }
    }
}
