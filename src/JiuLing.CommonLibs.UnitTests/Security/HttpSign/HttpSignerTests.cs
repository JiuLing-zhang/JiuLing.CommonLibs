using System.Collections.Generic;
using JiuLing.CommonLibs.Security.HttpSign;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiuLing.CommonLibs.UnitTests.Security.HttpSign
{
    [TestClass()]
    public class HttpSignerTests
    {
        private Dictionary<string, string> _signSource = new Dictionary<string, string>()
        {
            { "param1", "1" },
            { "param3", "3+" },
            { "param2", "2" }
        };
        private HttpSigner _signer = null;

        [TestMethod()]
        public void SetSignDataTest()
        {
            //常规
            _signer = new HttpSigner();
            _signer.SetSignData(_signSource);
            Assert.IsTrue(_signer.GetSignResult() == "param1=1&param3=3+&param2=2");

            //按参数名排序
            _signer = new HttpSigner();
            _signer.SetSignData(_signSource, setting =>
            {
                setting.IsOrderByWithKey = true;
            });
            Assert.IsTrue(_signer.GetSignResult() == "param1=1&param2=2&param3=3+");

            //参数项的连接符
            _signer = new HttpSigner();
            _signer.SetSignData(_signSource, setting =>
            {
                setting.SignTextItemSeparator = "|";
            });
            Assert.IsTrue(_signer.GetSignResult() == "param1=1|param3=3+|param2=2");

            //参数项和值的连接符
            _signer = new HttpSigner();
            _signer.SetSignData(_signSource, setting =>
            {
                setting.SignTextKeyValueSeparator = "-";
            });
            Assert.IsTrue(_signer.GetSignResult() == "param1-1&param3-3+&param2-2");

            //签名主体是否包含参数名
            _signer = new HttpSigner();
            _signer.SetSignData(_signSource, setting =>
            {
                setting.IsSignTextContainKey = false;
            });
            Assert.IsTrue(_signer.GetSignResult() == "1&3+&2");

            //签名数据的参数值进行UrlEncode
            _signer = new HttpSigner();
            _signer.SetSignData(_signSource, setting =>
            {
                setting.IsDoUrlEncodeForSourceValue = true;
            });
            Assert.IsTrue(_signer.GetSignResult() == "param1=1&param3=3%2b&param2=2");

        }

        [TestMethod()]
        public void SetSignTextPrefixTest()
        {
            _signer = new HttpSigner();
            _signer
                .SetSignData(_signSource)
                .SetSignTextPrefix("test");
            Assert.IsTrue(_signer.GetSignResult() == "testparam1=1&param3=3+&param2=2");
        }

        [TestMethod()]
        public void SetSignTextSuffixTest()
        {
            _signer = new HttpSigner();
            _signer
                .SetSignData(_signSource)
                .SetSignTextSuffix("test");
            Assert.IsTrue(_signer.GetSignResult() == "param1=1&param3=3+&param2=2test");
        }

        [TestMethod()]
        public void SetUrlEncodeTest()
        {
            _signer = new HttpSigner();
            _signer
                .SetSignData(_signSource)
                .SetUrlEncode();
            Assert.IsTrue(_signer.GetSignResult() == "param1%3d1%26param3%3d3%2b%26param2%3d2");
        }

        [TestMethod()]
        public void SetSignTextBase64Test()
        {
            _signer = new HttpSigner();
            _signer
                .SetSignData(_signSource)
                .SetSignTextBase64();
            Assert.IsTrue(_signer.GetSignResult() == "cGFyYW0xPTEmcGFyYW0zPTMrJnBhcmFtMj0y");
        }

        [TestMethod()]
        public void SetSignTextMD5Test()
        {
            _signer = new HttpSigner();
            _signer
                .SetSignData(_signSource)
                .SetSignTextMD5();
            Assert.IsTrue(_signer.GetSignResult() == "bfc9d5100ca7b95387ebcc0a20c7b842");

            _signer = new HttpSigner();
            _signer
                .SetSignData(_signSource)
                .SetSignTextMD5(false);
            Assert.IsTrue(_signer.GetSignResult() == "BFC9D5100CA7B95387EBCC0A20C7B842");
        }

        [TestMethod()]
        public void SetSignTextSHA1Test()
        {
            _signer = new HttpSigner();
            _signer
                .SetSignData(_signSource)
                .SetSignTextSHA1();
            Assert.IsTrue(_signer.GetSignResult() == "9938d10ceb9aebb7eae0847a9c920fa6a6ac4c88");

            _signer = new HttpSigner();
            _signer
                .SetSignData(_signSource)
                .SetSignTextSHA1(false);
            Assert.IsTrue(_signer.GetSignResult() == "9938D10CEB9AEBB7EAE0847A9C920FA6A6AC4C88");
        }

        [TestMethod()]
        public void GetSignResultTest()
        {
            _signer = new HttpSigner();
            Assert.IsNull(_signer.GetSignResult());
        }
    }
}