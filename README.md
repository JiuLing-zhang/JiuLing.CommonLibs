![](https://img.shields.io/badge/license-MIT-green) ![](https://img.shields.io/badge/%E7%8A%B6%E6%80%81-%E6%AD%A3%E5%9C%A8%E5%BC%80%E5%8F%91-red)  

# `.NET 5`通用类库
一个`.NET 5`下整理的通用类库。  

## :one: 由来
新建项目后，经常发现连个`string.IsEmpty()`都没有 :disappointed_relieved: 、来个`Json`的通用返回值吧，也没有:unamused: 还有等等等等等等等等。。。所以就决定整理并集成一下自己平时用的比较多的一些工具类，然后发布到`NuGet`，以后走那用那有木有:dog::dog:  

## :two: 类库使用说明
>通用说明：类库中以Helper结尾的类，都是静态方法

* `Collections`命名空间  
该命名空间下是一些集合相关的工具类
    * `DictionaryComparer`类：`Dictionary`对象对比工具

    ```C#
    var x = new Dictionary<string, string>();
    x.Add("a1", "b1");
    var y = new Dictionary<string, string>();
    y.Add("a1", "b1");
    Assert.IsTrue(_myComparer.Equals(x, y));
    ```

## :one: License
MIT License