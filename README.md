![](https://img.shields.io/github/license/JiuLing-zhang/JiuLing.CommonLibs)
![](https://img.shields.io/github/workflow/status/JiuLing-zhang/JiuLing.CommonLibs/release-job)
[![](https://img.shields.io/nuget/v/JiuLing.CommonLibs)](https://www.nuget.org/packages/JiuLing.CommonLibs/)
[![](https://img.shields.io/github/v/release/JiuLing-zhang/JiuLing.CommonLibs)](https://github.com/JiuLing-zhang/JiuLing.CommonLibs/releases)  
# 一个基于`.NET Standard 2.0`的通用类库
一个`.NET Standard 2.0`下整理的通用类库，基于`MIT License`。  

## :one: 项目初衷
新建项目后，经常发现连个`string.IsEmpty()`都没有、想要个`Json`的通用返回值吧，也没有:disappointed_relieved::disappointed_relieved:，当然，还有等等等等等等等等。。。所以我决定整理并集成一下自己平时用的比较多的一些工具类，然后发布到`NuGet`，以后走哪用哪啊有木有~~  

## :two: 帮助文档
> * 类库中以`Utils`结尾的类，都提供了静态方法，可以直接调用  
> * 类库中的命名空间和类名，尽量与`.NET`保持一致  

### `Collections`命名空间  
该命名空间下是一些集合相关的类

* `DictionaryComparer`类：`Dictionary`对象对比工具  

    ```C#
    var x = new Dictionary<string, string>();
    x.Add("a1", "b1");
    var y = new Dictionary<string, string>();
    y.Add("a1", "b1");
    Assert.IsTrue(_myComparer.Equals(x, y));
    ```

### `ExtensionMethods`命名空间  
该命名空间下是一些通用的扩展方法

* `EnumExtension`类：枚举类型的扩展方法

    ```C#
    public enum MyEnum
    {
        [Description("一")]
        One,
        [Description("二")]
        Two,
        Three
    }

    //获取枚举的描述信息，下面的例子将返回“一”
    MyEnum.One.GetDescription();
    //如果枚举字段没有设置Description特性，将返回自身的ToString()形式，下面的例子将返回“Three”
    MyEnum.Three.GetDescription();
    ```

* `StringExtension`类：字符串类型的扩展方法

    ```C#
    "abc".IsEmpty();  //字符串是否为空
    "abc".IsNotEmpty();  //字符串是否不为空
    "https://jiuling.me".ToUri();  //将字符串转为Uri对象
    ```

### `Log`命名空间  
该命名空间下是一些通用的日志帮助类

* `ILogger`接口：负责简单的日志的写入

    ```C#
    ILogger logger = LogManager.GetLogger();
    // logger.SetLogDirectory("C:\\")      //设置日志文件的路径，默认为“程序集路径\log”
    //     .SetFileNameFormat("yyyyMMdd")  //设置日志文件名的格式，默认为“yyyy-MM-dd”
    //     .SetFileExpandedName(".txt");   //设置日志文件的扩展名，默认为“.log”
    logger.Write("test");
    ```

### `Model`命名空间  
该命名空间下是一些通用的数据模型

* `JsonResult`类：通用的`Json`返回值模型

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

* `AppUpgradeInfo`类：通用的`App`自动更新所需的模型

    ```C#
    public class AppUpgradeInfo
    {
        /// <summary>
        /// 程序名称
        /// </summary>
        public string Name { get; set; }        
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
        /// 时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
    ```

### `Net`命名空间  
该命名空间下是网络相关的类

* `CookieUtils`类：`Cookie`相关的工具

    ```C#
    //将CookieContainer转换为指定格式的字符串形式，方便本地储存
    public static string CookieContainerToString(CookieContainer cookieContainer);

    //将指定格式的字符串转换为CookieContainer
    public static CookieContainer StringToCookieContainer(string cookies);
    ```

* `HttpClientHelper`类：网络请求类工具，使用`HttpClient`实现

    ```C#
    //异步发送一个GET请求，返回一个字符串
    public async Task<string> GetReadString(string url);

    //异步发送一个GET请求，返回一个字节数组
    public async Task<byte[]> GetReadByteArray(string url);

    //异步发送一个GET请求，返回一个文件的字节数组
    public async Task<byte[]> GetFileByteArray(string url, IProgress<float> progress = null, int bufferSize = 8192)

    //异步发送一个表单形式的Post请求，返回一个字符串
    public async Task<string> PostFormReadString(string url, IEnumerable<KeyValuePair<string, string>> data);

    //异步发送一个字符串形式的Post请求，返回一个字符串
    public async Task<string> PostStringReadString(string url, string data);

    //异步发送一个Json形式的Post请求（使用UTF8编码），返回一个字符串
    public async Task<string> PostJsonReadString(string url, string data);

    //异步发送一个表单形式的Post请求，返回一个字节数组
    public async Task<byte[]> PostFormReadByteArray(string url, IEnumerable<KeyValuePair<string, string>> data)
    ```

### `OS`命名空间  
该命名空间下是一些操作系统相关的类

* `VersionUtils`类：操作系统版本帮助类

    ```C#
    VersionUtils.IsWindows7;     //当前系统是否为Win7
    VersionUtils.IsWindows8;     //当前系统是否为Win8
    VersionUtils.IsWindows81;    //当前系统是否为Win8.1
    VersionUtils.IsWindows10;    //当前系统是否为Win10   
    ```
    ```C#
    //获取当前操作系统的版本，返回值为一个OSVersionEnum枚举值
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

### `Random`命名空间  
该命名空间下是一些随机数相关的类

* `RandomUtils`类：随机数帮助类

    ```C#
    RandomUtils.GetOneByLength();    //返回一个长度为10的随机数
    RandomUtils.GetOneByLength(20);  //返回一个长度为20的随机数

    //方法定义  T GetOneFromList<T>(IList<T> input)
    //随机返回list中的一个元素
    var list = new List<string>();
    list.Add("a");
    list.Add("b");
    RandomUtils.GetOneFromList<string>(list);
    ```

### `Security`命名空间  
该命名空间下是一些安全相关的类

* `MD5Utils`类：MD5帮助类

    ```C#
    //默认编码格式
    public static Encoding DefaultEncoding = Encoding.UTF8;

    //计算字符串的32位MD5值（小写）
    MD5Utils.GetLowerValue();
    //计算字符串的32位MD5值（大写）
    MD5Utils.GetUpperValue();
    ```

* `SHA1Utils`类：SHA1的帮助类

    ```C#
    //计算文件的SHA1值（小写）
    SHA1Utils.GetFileLowerValue();
    //计算文件的SHA1值（大写）
    SHA1Utils.GetFileUpperValue();
    ```

### `Text`命名空间  
该命名空间下是一些文本处理的类

* `RegexUtils`类：正则表达式相关的类

    ```C#
    //文本是否与正则表达式匹配
    RegexUtils.IsMatch(111,@"\d{3}");

    //根据正则表达式替换；该示例返回：<xxx>
    RegexUtils.Replace("<test>",@"test","xxx");

    //返回正则表达式的第一个匹配项；返回test12
    RegexUtils.GetFirst("test123test456", @"test\d{2}");

    //返回正则表达式匹配到的所有项
    RegexUtils.GetAll(input, pattern);

    //按照正则表达式分组名称返回第一个匹配项；a="jiuling"
    string a=GetOneGroupInFirstMatchTest("name:jiuling;age:0;",@"name:(?<name>\w*);");

    //按照正则表达式分组名称返回所有匹配项；如果没有匹配到任何项，success=false,否则result返回一个IDictionary对象，其Key值为Group的名称 
    (bool success, IDictionary<string, string> result)=RegexUtils.GetMultiGroupInFirstMatch("name:jiuling;age:0;",@"name:(?<name>\w*);age:(?<age>\w*);");
    //返回值 success=true,result["name"]="jiuling",result["age"]="0"
    ```

* `TimestampUtils`类：时间戳相关的类

    ```C#
    //获取一个10位的时间戳
    TimestampUtils.GetLen10();

    //获取一个13位的时间戳
    TimestampUtils.GetLen13();

    //将时间转换为一个10位的时间戳   1626961721
    TimestampUtils.ConvertToLen10("2021-07-22 21:48:41");

    //将时间转换为一个13位的时间戳   1626961721000
    TimestampUtils.ConvertToLen13("2021-07-22 21:48:41");

    //将10位或13位的时间戳转换为一个DateTime对象（该方法会自动判断长度）   2021-07-22 21:48:41
    TimestampUtils.ConvertToDateTime(1626961721000)
    ```

### `Threading`命名空间  
该命名空间下是一些线程相关的类

* `ThreadUtils`类：线程帮助类

    ```C#
    //随机将线程挂起1-10秒
    ThreadUtils.SleepRandomSecond(1,10);

    //随机将线程挂起1-10毫秒
    ThreadUtils.SleepRandomMillisecond(2000, 5000);
    ```

### 根命名空间  

* `GuidUtils`类：Guid帮助类
  
    ```C#
    //获取一个Guid，格式：9af7f46a-ea52-4aa3-b8c3-9fd484c2af12
    GuidUtils.GetFormatDefault();

    //获取一个Guid，格式：e0a953c3ee6040eaa9fae2b667060e09
    GuidUtils.GetFormatN();

    //获取一个Guid，格式：9af7f46a-ea52-4aa3-b8c3-9fd484c2af12
    GuidUtils.GetFormatD();

    //获取一个Guid，格式：{734fd453-a4f8-4c5d-9c98-3fe2d7079760}
    GuidUtils.GetFormatB();

    //获取一个Guid，格式：(ade24d16-db0f-40af-8794-1e08e2040df3)
    GuidUtils.GetFormatP();

    //获取一个Guid，格式：{0x3fa412e3,0x8356,0x428f,{0xaa,0x34,0xb7,0x40,0xda,0xaf,0x45,0x6f}}
    GuidUtils.GetFormatX();
    ```

* `VersionUtils`类：程序版本帮助类
  
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

## :three: License
本项目基于`MIT License`
