# 命名规则  
* 类库中以 `Utils` 结尾的类，都提供了静态方法，可以直接调用。  
* 类库中的命名空间和类名，尽量与 `.NET` 保持一致。  
* 为了节约篇幅，命名空间（根命名空间除外）名称不包含 `JiuLing.CommonLibs.` 前缀。  

# `Collections` 命名空间  
该命名空间下是一些集合相关的类。  

## `DictionaryComparer` 类  
`Dictionary` 对象对比工具。  

```C#
var x = new Dictionary<string, string>();
x.Add("a1", "b1");
var y = new Dictionary<string, string>();
y.Add("a1", "b1");
Assert.IsTrue(_myComparer.Equals(x, y));
```

# `ExtensionMethods` 命名空间  
该命名空间下是一些通用的扩展方法。  

## `EnumExtension` 类  
枚举类型的扩展方法。  

```C#
public enum MyEnum
{
    [System.ComponentModel.Description("一")]
    One,
    [System.ComponentModel.Description("二")]
    Two,
    Three
}

//获取枚举的描述信息，下面的例子将返回“一”
MyEnum.One.GetDescription();
//如果枚举字段没有设置Description特性，将返回自身的ToString()形式，下面的例子将返回“Three”
MyEnum.Three.GetDescription();
```

## `JsonExtension` 类  
`Json` 的一些扩展方法，基于 `System.Text.Json` 实现。  
由于在非 `MVC` 项目中，`json` 操作无法支持设置通用 `JsonSerializerOptions`，因此扩展一下。  

```C#
//设置通用 JsonSerializerOptions
JsonExtension.DefaultOptions = new JsonSerializerOptions();

//String to model
public static T ToObject<T>(this string json);

//Model to string
public static string ToJson<T>(this T value);
```

## `ListExtendTools` 类  
List 的一些扩展方法。  

`List` 转 `DataTable`  

```C#
var a=new List<T>();
a.ToDataTable();
```

## `StringExtension` 类  
字符串类型的扩展方法。  

```C#
"abc".IsEmpty();  //字符串是否为空
"abc".IsNotEmpty();  //字符串是否不为空
"abc".IsTrimEmpty();  //Trim 后的字符串是否为空
"abc".IsNotTrimEmpty();  //Trim 后的字符串是否不为空
"https://jiuling.me".ToUri();  //将字符串转为 Uri 对象
```

# `Log` 命名空间  
该命名空间下是一些通用的日志帮助类。  

## `ILogger` 接口  
负责简单的日志的写入。  

```C#
ILogger logger = LogManager.GetLogger();
// logger.SetLogDirectory("C:\\")      //设置日志文件的路径，默认为 “程序集路径\log”
//     .SetFileNameFormat("yyyyMMdd")  //设置日志文件名的格式，默认为 “yyyy-MM-dd”
//     .SetFileExpandedName(".txt");   //设置日志文件的扩展名，默认为 “.log”
logger.Write("test");
```

# `Middleware` 命名空间  
该命名空间下是一个简单的异步中间件。  

## 异步中间件
1. 了解中间件 `IMiddleware` 接口。  

    * `TContext` : 中间件传递的上下文类型，目前仅支持引用类型。
    * `IsExecuteNext` : 指示是否执行后续的中间件。
    * `InvokeAsync` : 中间件的具体异步实现。

2. 中间件具体实现。  

```C#
    //中间件 1
    internal class MiddlewareAsyncTest1 : IMiddleware<List<int>>
    {
        public bool IsExecuteNext { get; set; } = true;
        public Task InvokeAsync(List<int> context)
        {
            context.Add(1);
            return Task.CompletedTask;
        }
    }

    //中间件 2
    internal class MiddlewareAsyncTest2 : IMiddleware<List<int>>
    {
        public bool IsExecuteNext { get; set; }
        public Task InvokeAsync(List<int> context)
        {
            context.Add(2);
            //不在执行后续中间件
            IsExecuteNext = false;
            return Task.CompletedTask;
        }
    }

    //中间件 3
    internal class MiddlewareAsyncTest3 : IMiddleware<List<int>>
    {
        public bool IsExecuteNext { get; set; }
        public Task InvokeAsync(List<int> context)
        {
            context.Add(3);
            return Task.CompletedTask;
        }
    }
```

3. 构建中间件  

```C#
    var builder = Middleware.CreateBuilder<List<int>>();
    builder
        .Use(new MiddlewareAsyncTest1())
        .Use(new MiddlewareAsyncTest2())
        .Use(new MiddlewareAsyncTest3());
```

4. 执行中间件  

```C#
    //方法入参是初始化的上下文，返回值是执行完的上下文。
    var result = await builder.ExecuteAsync(new List<int>());
```

# `Model` 命名空间  
该命名空间下是一些通用的数据模型。  

## `JsonResult` 类  
通用的 `Json` 返回值模型。  

```C#
public class JsonResult
{
    public int Code { get; set; }
    public string Message { get; set; }
}
```

```C#
public class JsonResult<T>
{
    public int Code { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}
```

## `AppUpgradeInfo` 类  
通用的 `App` 自动更新所需的模型。  

```C#
public class AppUpgradeInfo
{
    /// <summary>
    /// 程序名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 版本号
    /// </summary>
    public int VersionCode { get; set; }
    /// <summary>
    /// 当前版本
    /// </summary>
    public string Version { get; set; }
    /// <summary>
    /// 程序运行的最小版本
    /// </summary>
    public string MinVersion { get; set; }
    /// <summary>
    /// 下载地址
    /// </summary>
    public string DownloadUrl { get; set; }
    /// <summary>
    /// 更新日志
    /// </summary>
    public string Log { get; set; }
    /// <summary>
    /// 文件签名类型（例如 MD5、SHA1 等）
    /// </summary>
    public string SignType { get; set; }
    /// <summary>
    /// 签名值
    /// </summary>
    public string SignValue { get; set; }
    /// <summary>
    /// 时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 文件大小
    /// </summary>
    public int FileLength { get; set; }
}
```

# `Net` 命名空间  
该命名空间下是网络相关的类。  

## `BrowserDefaultHeader` 类  
浏览器的默认 Request headers。  
**数据版本：2022-07-13**

```C#
//Edge 浏览器
public static Dictionary<string, string> EdgeHeaders;
//Edge的 User-Agent参数
public static string EdgeUserAgent;

//Chrome 浏览器
public static Dictionary<string, string> ChromeHeaders;
//Chrome的 User-Agent参数
public static string ChromeUserAgent;

//Firefox 浏览器
public static Dictionary<string, string> FirefoxHeaders;
//Firefox的 User-Agent参数
public static string FirefoxUserAgent;

```

## `CookieUtils` 类  
`Cookie` 相关的工具。  

```C#
//将 CookieContainer 转换为指定格式的字符串形式，方便本地储存
public static string CookieContainerToString(CookieContainer cookieContainer);

//将指定格式的字符串转换为 CookieContainer
public static CookieContainer StringToCookieContainer(string cookies);
```

## `HttpClientHelper` 类  
网络请求类工具，使用 `HttpClient` 实现。  

```C#
//异步发送一个 GET 请求，返回一个字符串
public async Task<string> GetReadString(string url);

//异步发送一个 GET 请求，返回一个字节数组
public async Task<byte[]> GetReadByteArray(string url);

//异步发送一个 GET 请求，返回一个文件的字节数组
public async Task<byte[]> GetFileByteArray(string url, IProgress<float> progress = null, int bufferSize = 8192)

//异步发送一个表单形式的 Post 请求，返回一个字符串
public async Task<string> PostFormReadString(string url, IEnumerable<KeyValuePair<string, string>> data);

//异步发送一个字符串形式的 Post 请求，返回一个字符串
public async Task<string> PostStringReadString(string url, string data);

//异步发送一个 Json 形式的 Post 请求（使用 UTF8 编码），返回一个字符串
public async Task<string> PostJsonReadString(string url, string data);

//异步发送一个表单形式的 Post 请求，返回一个字节数组
public async Task<byte[]> PostFormReadByteArray(string url, IEnumerable<KeyValuePair<string, string>> data)
```

# `OS` 命名空间  
该命名空间下是一些操作系统相关的类。  

## `VersionUtils` 类  
操作系统版本帮助类。  

```C#
VersionUtils.IsWindows7;     //当前系统是否为 Windows 7
VersionUtils.IsWindows8;     //当前系统是否为 Windows 8
VersionUtils.IsWindows81;    //当前系统是否为 Windows 8.1
VersionUtils.IsWindows10;    //当前系统是否为 Windows 10   
```
```C#
//获取当前操作系统的版本，返回值为一个 OSVersionEnum 枚举值
VersionUtils.GetOSVersion();

public enum OSVersionEnum
{
    [Description("Windows7")]
    Windows7,
    [Description("Windows8")]
    Windows8,
    [Description("Windows8.1")]
    Windows81,
    [Description("Windows10")]
    Windows10,
    [Description("未知")]
    Unknown,
}
```

# `Security` 命名空间  
该命名空间下是一些安全相关的类。  

## `SignatureBuilder` 类  
签名构建工具。  
该类在 `Security.Signature` 命名空间下。  

```C#

//初始化构建器
var signSource = new Dictionary<string, string>()
{
    { "param1", "1" },
    { "param3", "3+" },
    { "param2", "2" }
};
var builder = SignatureBuilder.Create(signSource);
var builder = SignatureBuilder.Create("param1=1&param3=3+&param2=2");

//获取签名
//链式实现，可自由组合
var sign = builder
            .OrderBy()//字典序
            .FetchParameterValue()//提取参数值
            .FetchParameterNameAndValue() //提取参数名和参数值
            .Base64()
            .Prefix("Prefix")//添加前缀
            .Postfix("Postfix")//添加后缀
            .UrlEncodeUpper()//大写编码
            .UrlEncodeLower() //小写编码
            .MD5()
            .SHA1()
            .SHA256()
            .ToUpper()
            .ToLower()
            .GetResult(); //获取最终的签名结果
Console.WriteLine(sign);
```

## `MD5Utils` 类  
Base64 的工具类。  

```C#
//默认编码格式
public static Encoding DefaultEncoding = Encoding.UTF8;

//Base64 转字符串
string Base64ToString(string input);
//字符串转 Base64
string StringToBase64(string input);
```

## `MD5Utils` 类  
MD5 帮助类。  

```C#
//默认编码格式
public static Encoding DefaultEncoding = Encoding.UTF8;

//计算字符串的 32 位 MD5 值（小写）
string GetStringValueToLower(string input);
//计算字符串的 32 位 MD5 值（大写）
string GetStringValueToUpper(string input);

//计算文件的 MD5 值（小写）
string GetFileValueToUpper(string fileName);
string GetFileValueToUpper(Stream stream);
//计算文件的 MD5 值（大写）
string GetFileValueToUpper(string fileName);
string GetFileValueToUpper(Stream stream);
```

## `SHA1Utils` 类  
SHA1 的帮助类。  

```C#
//计算字符串的 SHA1 值（小写）
string GetStringValueToLower(string fileName);
//计算字符串的 SHA1 值（大写）
string GetFileValueToUpper(string fileName);

//计算文件的 SHA1 值（小写）
string GetFileValueToLower(string fileName);
string GetFileValueToLower(Stream stream);
string GetFileValueToLower(byte[] buffer);

//计算文件的 SHA1 值（大写）
string GetFileValueToUpper(string fileName);
string GetFileValueToUpper(Stream stream);
string GetFileValueToUpper(byte[] buffer);
```

## `SHA256Utils` 类  
SHA256 的帮助类。  

```C#
//计算字符串的 SHA256 值（小写）
string GetStringValueToLower(string fileName);
//计算字符串的 SHA256 值（大写）
string GetFileValueToUpper(string fileName);

//计算文件的 SHA256 值（小写）
string GetFileValueToLower(string fileName);
string GetFileValueToLower(Stream stream);
//计算文件的 SHA256 值（大写）
string GetFileValueToUpper(string fileName);
string GetFileValueToUpper(Stream stream);
```

# `Text` 命名空间  
该命名空间下是一些文本处理的类。  

## `RegexUtils` 类  
正则表达式相关的类。  

```C#
//文本是否与正则表达式匹配
RegexUtils.IsMatch(111,@"\d{3}");

//根据正则表达式替换；该示例返回：<xxx>
RegexUtils.Replace("<test>",@"test","xxx");

//返回正则表达式的第一个匹配项；返回 test12
RegexUtils.GetFirst("test123test456", @"test\d{2}");

//返回正则表达式匹配到的所有项
RegexUtils.GetAll(input, pattern);

//根据正则表达式获取输入字符串中的所有匹配项；如果没有匹配到任何项，返回一个空列表,否则返回匹配到的所有项。
List<string> GetOneGroupAllMatch("<div>a1</div><div>a2</div><div>a3</div>", @"<div>(?<value>[\s\S]*?)<\/div>");
//返回值 new List<string>{ "a1", "a2", "a3" }

//按照正则表达式分组名称返回第一个匹配项；如果没有匹配到任何项，success = false,否则 result 返回匹配到的数据。
(bool success, string result) GetOneGroupInFirstMatch("name:jiuling;age:0;",@"name:(?<name>\w*);");
//返回值 success=true,result="jiuling"

//按照正则表达式分组名称返回所有匹配项；如果没有匹配到任何项，success = false,否则 result 返回一个 IDictionary 对象，其 Key 值为 Group 的名称 
(bool success, IDictionary<string, string> result)=RegexUtils.GetMultiGroupInFirstMatch("name:jiuling;age:0;",@"name:(?<name>\w*);age:(?<age>\w*);");
//返回值 success=true,result["name"]="jiuling",result["age"]="0"
```

## `StartupCommandUtils` 类  
启动参数解析工具类。  

检查是否包含参数。  

```C#
StartupCommandUtils.Initialize("-a test1 test2 -b");    
bool result = StartupCommandUtils.HasCommand("-a");
//result 的值为 True
```

获取指定参数。  

```C#
StartupCommandUtils.Initialize("-a test1 test2 -b -c test-c");
IList<string> result = StartupCommandUtils.GetCommandValue("-a");
//result包含"test1"和"test3"两个值
```

尝试获取指定参数

```C#
StartupCommandUtils.Initialize("-a test1 -b test");    
bool result = StartupCommandUtils.TryGetCommandValue("-a", out args);
//result为是否找到对应参数，args为获取到的参数值
```

## `TimestampUtils` 类  
时间戳相关的类。  

```C#
//获取一个 10 位的时间戳
TimestampUtils.GetLen10();

//获取一个 13 位的时间戳
TimestampUtils.GetLen13();

//将时间转换为一个 10 位的时间戳   1626961721
TimestampUtils.ConvertToLen10("2021-07-22 21:48:41");

//将时间转换为一个 13 位的时间戳   1626961721000
TimestampUtils.ConvertToLen13("2021-07-22 21:48:41");

//将 10 位或 13 位的时间戳转换为一个 DateTime 对象（该方法会自动判断长度）   2021-07-22 21:48:41
TimestampUtils.ConvertToDateTime(1626961721000)
```

# `Threading` 命名空间  
该命名空间下是一些线程相关的类。  

## `AppUtils` 类  
应用程序相关的工具类。  

```C#
//检查 App 是否重复运行（用于判断多开）
bool isRerun = AppUtils.IsRerun("JiuLing.CommonLibs.Test");
```

## `SpinLock` 类  
一个自旋锁。  
**不建议用于 IO 高并发场景。**

```C#
var spinLock = new SpinLock();
spinLock.Enter();
//Do your jobs
spinLock.Exit();
```

## `ThreadUtils` 类  
线程帮助类。  

```C#
//随机将线程挂起 1~10 秒
ThreadUtils.SleepRandomSecond(1,10);

//随机将线程挂起 2000~5000 毫秒
ThreadUtils.SleepRandomMillisecond(2000, 5000);
```

# 根命名空间  

## `CommandLineArgsHelper` 类  
命令行参数解析工具。  

```C#
//实例化工具类，并且通过 Environment.GetCommandLineArgs() 获取启动参数
var helper = new CommandLineArgsHelper();
//通过指定的参数集合实例化工具类
var helper = new CommandLineArgsHelper(string[] args);
var helper = new CommandLineArgsHelper(string args);

//判断是否包含指定参数
bool HasCommand(string key);
helper.HasCommand("-t");

//获取指定参数名的参数值
List<string> GetCommandValue(string key);
var args = helper.HasCommand("-t");

//尝试获取指定参数名的参数值，并返回是否获取成功
bool TryGetCommandValue(string key, out List<string> value);
var result = helper.HasCommand("-t", out args);
```

## `GuidUtils` 类  
Guid 帮助类。  
  
```C#
//获取一个 Guid，格式：9af7f46a-ea52-4aa3-b8c3-9fd484c2af12
GuidUtils.GetFormatDefault();

//获取一个 Guid，格式：e0a953c3ee6040eaa9fae2b667060e09
GuidUtils.GetFormatN();

//获取一个 Guid，格式：9af7f46a-ea52-4aa3-b8c3-9fd484c2af12
GuidUtils.GetFormatD();

//获取一个 Guid，格式：{734fd453-a4f8-4c5d-9c98-3fe2d7079760}
GuidUtils.GetFormatB();

//获取一个 Guid，格式：(ade24d16-db0f-40af-8794-1e08e2040df3)
GuidUtils.GetFormatP();

//获取一个 Guid，格式：{0x3fa412e3,0x8356,0x428f,{0xaa,0x34,0xb7,0x40,0xda,0xaf,0x45,0x6f}}
GuidUtils.GetFormatX();
```

## `RandomUtils` 类  
随机数帮助类。  

```C#
RandomUtils.GetOneByLength();    //返回一个长度为 10 的随机数
RandomUtils.GetOneByLength(20);  //返回一个长度为 20 的随机数

//方法定义  T GetOneFromList<T>(IList<T> input)
//随机返回 list 中的一个元素
var list = new List<string>();
list.Add("a");
list.Add("b");
RandomUtils.GetOneFromList<string>(list);
```

```C#
//获取一个指定长度的 16 进制随机数（小写）
//返回 fdd1eada
RandomUtils.GetOneHexByLengthToLower(4);

//获取一个指定长度的 16 进制随机数（大写）
//返回 A46D59A4
RandomUtils.GetOneHexByLengthToUpper(4);
```

## `TempIdGenerator` 类  
一个线程安全的临时 Id 生成器。  

```C#
//创建一个 6 位 Id 的生成器
var tempIdGenerator = new TempIdGenerator(6);

//生成 Id。expiration 参数是 Id 的过期时间。
DateTime expiration = DateTime.Now.AddSeconds(5);
var id = tempIdGenerator.Create(expiration);

//生成 Id。expiration 参数是 Id 的过期时间。
var time = DateTime.Now;
TimeSpan expiration = time.AddSeconds(5).Subtract(time);
var id = tempIdGenerator.Create(expiration);
```

## `VersionUtils` 类  
程序版本帮助类。  

```C#
//检查当前版本是否需要更新
bool CheckNeedUpdate(Version currentVersion, Version newVersion);

//检查当前版本是否需要更新
bool CheckNeedUpdate(string currentVersion, string newVersion);

//检查当前版本是否需要更新。返回（是否需要自动更新，当前版本是否允许使用）
(bool IsNeedUpdate, bool IsAllowUse) CheckNeedUpdate(Version currentVersion, Version newVersion, Version minVersion)

//检查当前版本是否需要更新。返回（是否需要自动更新，当前版本是否允许使用）
(bool IsNeedUpdate, bool IsAllowUse) CheckNeedUpdate(string currentVersion, string newVersion, string minVersion)
```