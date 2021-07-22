using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JiuLing.CommonLibs.Net
{
    /// <summary>
    /// 网络请求工具
    /// </summary>
    public class HttpClientTools
    {
        private static HttpClient _httpClient;
        public HttpClientTools()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// 发送一个GET请求
        /// </summary>
        /// <param name="url">请求的URL</param>
        /// <returns>返回服务器请求得到的字符串</returns>
        public async Task<string> GetReadString(string url)
        {
            return await _httpClient.GetStringAsync(url);
        }

        /// <summary>
        /// 发送一个GET请求
        /// </summary>
        /// <param name="url">请求的URL</param>
        /// <returns>返回服务器请求得到的字节数组</returns>
        public async Task<byte[]> GetReadByteArray(string url)
        {
            return await _httpClient.GetByteArrayAsync(url);
        }

        /// <summary>
        /// 发送一个表单形式的Post请求
        /// </summary>
        /// <param name="url">要请求的URL</param>
        /// <param name="data">表单参数</param>
        /// <returns>返回服务器请求得到的字符串</returns>
        public async Task<string> PostFormReadString(string url, IEnumerable<KeyValuePair<string, string>> data)
        {
            var form = new FormUrlEncodedContent(data);
            var response = await _httpClient.PostAsync(url, form);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 发送一个表单形式的Post请求
        /// </summary>
        /// <param name="url">要请求的URL</param>
        /// <param name="data">表单参数</param>
        /// <returns>返回服务器请求得到的字节数组</returns>
        public async Task<byte[]> PostFormReadByteArray(string url, IEnumerable<KeyValuePair<string, string>> data)
        {
            var form = new FormUrlEncodedContent(data);
            var response = await _httpClient.PostAsync(url, form);
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
