namespace JiuLing.CommonLibs.Model
{
    /// <summary>
    /// 一个通用的Json返回值模型
    /// </summary>
    public class JsonResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// 一个通用的Json返回值模型
    /// </summary>
    public class JsonResult<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
