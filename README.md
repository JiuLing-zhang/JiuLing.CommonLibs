![](https://img.shields.io/badge/build-passing-brightgreen)
![](https://img.shields.io/badge/test-passing-brightgreen)
![](https://img.shields.io/github/license/JiuLing-zhang/JiuLing.CommonLibs)
[![](https://img.shields.io/nuget/v/JiuLing.CommonLibs)](https://www.nuget.org/packages/JiuLing.CommonLibs/)  

# 一个基于`.NET Standard 2.0`的通用类库
一个`.NET Standard 2.0`下整理的通用类库。  

## :one: 项目初衷
新建项目后，经常发现连个`string.IsEmpty()`都没有、想要个`Json`的通用返回值吧，也没有:disappointed_relieved::disappointed_relieved:，当然，还有等等等等等等等等。。。所以我决定整理并集成一下自己平时用的比较多的一些工具类，然后发布到`NuGet`，以后走哪用哪啊有木有~~  

## :two: 使用说明
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

* `JsonResult`类：一个通用的`Json`返回值模型

    ```C#
    public class JsonResult<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
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

    //异步发送一个表单形式的Post请求，返回一个字符串
    public async Task<string> PostFormReadString(string url, IEnumerable<KeyValuePair<string, string>> data);

    //异步发送一个表单形式的Post请求，返回一个字节数组
    public async Task<byte[]> PostFormReadByteArray(string url, IEnumerable<KeyValuePair<string, string>> data)
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

### `Text`命名空间  
该命名空间下是一些文本处理的类

* `RegexUtils`类：正则表达式相关的类

    ```C#
    //文本是否与正则表达式匹配
    RegexUtils.IsMatch(111,@"\d{3}");

    //返回正则表达式的第一个匹配项；返回test12
    RegexUtils.GetFirst("test123test456", @"test\d{2}");

    //返回正则表达式匹配到的所有项
    RegexUtils.GetAll(input, pattern);

    //按照正则表达式分组名称返回第一个匹配项；a="jiuling"
    string a=GetOneGroupInFirstMatchTest("name:jiuling;age:0;",@"name:(?<name>\w*);");

    //按照正则表达式分组名称返回所有匹配项；obj.name="jiuling"  obj.age="0" 
    dynamic obj=RegexUtils.GetMultiGroupInFirstMatch("name:jiuling;age:0;",@"name:(?<name>\w*);age:(?<age>\w*);");
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

## :three: License
本项目基于`MIT License`
