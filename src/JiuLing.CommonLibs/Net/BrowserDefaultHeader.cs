using System.Collections.Generic;

namespace JiuLing.CommonLibs.Net
{
    /// <summary>
    /// 浏览器的默认Request headers (数据版本：2022-07-13)
    /// </summary>
    public class BrowserDefaultHeader
    {
        /// <summary>
        /// Edge的 User-Agent参数
        /// </summary>
        public static string EdgeUserAgent => "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49";

        /// <summary>
        /// Edge 浏览器
        /// </summary>
        public static Dictionary<string, string> EdgeHeaders => new Dictionary<string, string>()  {
            {"Accept","text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"},
            {"Accept-Encoding","gzip, deflate"},
            {"Accept-Language","zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6"},
            {"User-Agent",EdgeUserAgent},
            {"Connection","keep-alive"},
            {"Cache-Control","no-cache"},
            {"Pragma","no-cache"},
            {"Upgrade-Insecure-Requests","1"}
        };

        /// <summary>
        /// Chrome的 User-Agent参数
        /// </summary>
        public static string ChromeUserAgent => "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";
        /// <summary>
        /// Chrome 浏览器
        /// </summary>
        public static Dictionary<string, string> ChromeHeaders => new Dictionary<string, string>()
        {
            {"Accept","text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"},
            {"Accept-Encoding","gzip, deflate"},
            {"Accept-Language","zh-CN,zh;q=0.9"},
            {"User-Agent",ChromeUserAgent},
            {"Upgrade-Insecure-Requests","1"},
            {"Connection","keep-alive"}
        };

        /// <summary>
        /// Firefox的 User-Agent参数
        /// </summary>
        public static string FirefoxUserAgent => "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:102.0) Gecko/20100101 Firefox/102.0";

        /// <summary>
        /// Firefox 浏览器
        /// </summary>
        public static Dictionary<string, string> FirefoxHeaders => new Dictionary<string, string>()
        {
            {"Accept","text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8"},
            {"Accept-Encoding","gzip, deflate"},
            {"Accept-Language","zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2"},
            {"User-Agent",FirefoxUserAgent},
            {"Upgrade-Insecure-Requests","1"},
            {"Connection","keep-alive"}
        };

        /// <summary>
        /// Iphone 的 User-Agent 参数
        /// </summary>
        public static string IphoneUserAgent => "Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1";

    }
}
