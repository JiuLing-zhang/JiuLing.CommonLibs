using System;
using System.Collections.Generic;
using System.Linq;

namespace JiuLing.CommonLibs.Security.HttpSign
{
    /// <summary>
    /// 网络请求签名工具
    /// </summary>
    [Obsolete("该功能将在 v1.7 版本中删除，请改用 Security.Signature.SignatureBuilder 实现")]
    public class HttpSigner
    {
        /// <summary>
        /// 签名配置
        /// </summary>
        private readonly HttpSignSetting _setting = new HttpSignSetting();
        /// <summary>
        /// 最终的签名串
        /// </summary>
        private string _signString;

        /// <summary>
        /// 设置签名数据
        /// </summary>
        /// <param name="signSource">待签名的键值对</param>
        /// <param name="setting">配置签名规则</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public HttpSigner SetSignData(Dictionary<string, string> signSource, Action<HttpSignSetting> setting = null)
        {
            setting?.Invoke(_setting);
            if (_setting == null)
            {
                throw new ArgumentNullException(nameof(setting), "无效的签名配置");
            }

            if (signSource == null || signSource.Count == 0)
            {
                throw new ArgumentException("待签名数据异常", nameof(signSource));
            }

            var signSourceList = new List<HttpSignItem>(signSource.Count);
            foreach (var item in signSource)
            {
                var itemValue = item.Value;
                if (_setting.IsDoUrlEncodeForSourceValue)
                {
                    itemValue = System.Web.HttpUtility.UrlEncode(itemValue, _setting.DefaultEncoding);
                }
                signSourceList.Add(new HttpSignItem(item.Key, itemValue));
            }

            if (_setting.IsOrderByWithKey)
            {
                signSourceList = signSourceList.OrderBy(x => x.Key).ToList();
            }

            if (_setting.IsSignTextContainKey)
            {
                _signString = string.Join(_setting.SignTextItemSeparator, signSourceList.Select(x => $"{x.Key}{_setting.SignTextKeyValueSeparator}{x.Value}"));
            }
            else
            {
                _signString = string.Join(_setting.SignTextItemSeparator, signSourceList.Select(x => x.Value));
            }

            return this;
        }

        /// <summary>
        /// 签名主体设置前缀
        /// </summary>
        /// <param name="input">前缀值</param>
        /// <returns></returns>
        public HttpSigner SetSignTextPrefix(string input)
        {
            _signString = $"{input}{_signString}";
            return this;
        }

        /// <summary>
        /// 签名主体设置后缀
        /// </summary>
        /// <param name="input">后缀值</param>
        /// <returns></returns>
        public HttpSigner SetSignTextSuffix(string input)
        {
            _signString = $"{_signString}{input}";
            return this;
        }

        /// <summary>
        /// 签名主体设置后缀
        /// </summary>
        /// <returns></returns>
        public HttpSigner SetUrlEncode()
        {
            _signString = System.Web.HttpUtility.UrlEncode(_signString, _setting.DefaultEncoding);
            return this;
        }

        /// <summary>
        /// 签名主体进行Base64
        /// </summary>
        /// <returns></returns>
        public HttpSigner SetSignTextBase64()
        {
            _signString = Base64Utils.StringToBase64(_signString);
            return this;
        }

        /// <summary>
        /// 签名主体进行MD5
        /// </summary>
        /// <param name="isToLower">签名结果是否转小写</param>
        /// <returns></returns>
        public HttpSigner SetSignTextMD5(bool isToLower = true)
        {
            if (isToLower)
            {
                _signString = MD5Utils.GetStringValueToLower(_signString);
            }
            else
            {
                _signString = MD5Utils.GetStringValueToUpper(_signString);
            }
            return this;
        }

        /// <summary>
        /// 签名主体进行SHA1
        /// </summary>
        /// <param name="isToLower">签名结果是否转小写</param>
        /// <returns></returns>
        public HttpSigner SetSignTextSHA1(bool isToLower = true)
        {
            if (isToLower)
            {
                _signString = SHA1Utils.GetStringValueToLower(_signString);
            }
            else
            {
                _signString = SHA1Utils.GetStringValueToUpper(_signString);
            }
            return this;
        }

        /// <summary>
        /// 获取签名结果
        /// </summary>
        /// <returns></returns>
        public string GetSignResult()
        {
            return _signString;
        }
    }
}
