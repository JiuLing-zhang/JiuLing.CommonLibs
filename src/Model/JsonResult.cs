namespace JiuLing.CommonLibs.Model
{
    /// <summary>
    /// 一个通用的Json返回值模型
    /// </summary>
    public class JsonResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// 一个通用的Json返回值模型
    /// </summary>
    public class JsonResult<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 附加数据
        /// </summary>
        public T Data { get; set; }
    }
}
