namespace JiuLing.CommonLibs.Security.HttpSign
{
    internal class HttpSignItem
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public HttpSignItem(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
