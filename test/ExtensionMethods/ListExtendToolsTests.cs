using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiuLing.CommonLibs.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuLing.CommonLibs.ExtensionMethods.Tests
{
    [TestClass()]
    public class ListExtendToolsTests
    {
        public class Model
        {
            public string A { get; set; }
            public string B { get; set; }
        }
        [TestMethod()]
        public void ToDataTableTest()
        {
            var list = new List<Model>
            {
                new Model()
                {
                    A = "a1",
                    B = "b1"
                },
                new Model()
                {
                    A = "a2",
                    B = "b2"
                }
                ,
                new Model()
                {
                    A = "a3",
                    B = "b3"
                }
            };

            var dt = list.ToDataTable();
            Assert.IsTrue(dt.Rows.Count == list.Count && dt.Columns.Count == 2);
        }
    }
}