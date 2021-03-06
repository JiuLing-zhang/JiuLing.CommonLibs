using System.Collections.Generic;

namespace JiuLing.CommonLibs.Net
{
    /// <summary>
    /// 浏览器的默认Request headers (数据版本：2022-07-13)
    /// </summary>
    public class BrowserDefaultHeader
    {
        /// <summary>
        /// Edge 浏览器
        /// </summary>
        public static Dictionary<string, string> EdgeHeaders => new Dictionary<string, string>()  {
            {"Accept","text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"},
            {"Accept-Encoding","gzip, deflate"},
            {"Accept-Language","zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6"},
            {"User-Agent","Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49"},
            {"Connection","keep-alive"},
            {"Cache-Control","no-cache"},
            {"Pragma","no-cache"},
            {"Upgrade-Insecure-Requests","1"}
        };

        /// <summary>
        /// Chrome 浏览器
        /// </summary>
        public static Dictionary<string, string> ChromeHeaders => new Dictionary<string, string>()
        {
            {"Accept","text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"},
            {"Accept-Encoding","gzip, deflate"},
            {"Accept-Language","zh-CN,zh;q=0.9"},
            {"User-Agent","Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36"},
            {"Upgrade-Insecure-Requests","1"},
            {"Connection","keep-alive"}
        };

        /// <summary>
        /// Firefox 浏览器
        /// </summary>
        public static Dictionary<string, string> FirefoxHeaders => new Dictionary<string, string>()
        {
            {"Accept","text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8"},
            {"Accept-Encoding","gzip, deflate"},
            {"Accept-Language","zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2"},
            {"User-Agent","Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:102.0) Gecko/20100101 Firefox/102.0"},
            {"Upgrade-Insecure-Requests","1"},
            {"Connection","keep-alive"}
        };
    }
}
