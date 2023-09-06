using System.Text;

namespace JiuLing.CommonLibs.Security.HttpSign
{
    /// <summary>
    /// 签名配置
    /// </summary>
    public class HttpSignSetting
    {
        /// <summary>
        /// 是否按参数名进行排序
        /// </summary>
        public bool IsOrderByWithKey { get; set; } = false;

        /// <summary>
        /// 是否对签名数据的参数值进行UrlEncode
        /// </summary>
        public bool IsDoUrlEncodeForSourceValue { get; set; } = false;

        /// <summary>
        /// 签名主体是否包含参数名
        /// </summary>
        public bool IsSignTextContainKey { get; set; } = true;

        /// <summary>
        /// 签名主体中参数和参数值的连接符（需要启用IsSignTextContainKey）
        /// </summary>
        public string SignTextKeyValueSeparator { get; set; } = "=";

        /// <summary>
        /// 签名主体中不同参数项的连接符
        /// </summary>
        public string SignTextItemSeparator { get; set; } = "&";

        /// <summary>
        /// 编码
        /// </summary>
        public Encoding DefaultEncoding { get; set; } = Encoding.UTF8;
    }
}
