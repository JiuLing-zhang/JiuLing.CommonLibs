using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace JiuLing.CommonLibs.Net
{
    /// <summary>
    /// Cookie帮助类
    /// </summary>
    public class CookieUtils
    {
        /// <summary>
        /// 将CookieContainer转换为指定格式的字符串形式
        /// </summary>
        /// <param name="cookieContainer">要转换的CookieContainer</param>
        /// <returns></returns>
        public static string CookieContainerToString(CookieContainer cookieContainer)
        {
            string result = "";
            var cookieList = CookieContainerToList(cookieContainer);
            foreach (Cookie cookie in cookieList)
            {
                result = $"{result}{cookie.Name}^{cookie.Value}^{cookie.Domain}^{cookie.Path}^{cookie.Expires}\n";
            }
            return result;
        }

        private static List<Cookie> CookieContainerToList(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();
            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });

            if (table == null)
            {
                throw new NullReferenceException("CookieContainer对象内部结构解析失败");
            }
            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                                                             | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                if (lstCookieCol == null)
                {
                    throw new NullReferenceException("CookieContainer解析失败");
                }
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }
            return lstCookies;
        }

        /// <summary>
        /// 将指定格式的字符串转换为CookieContainer
        /// </summary>
        /// <param name="cookies">要转换的字符串</param>
        /// <returns></returns>
        public static CookieContainer StringToCookieContainer(string cookies)
        {
            var cc = new CookieContainer();
            string[] cookieRows = cookies.Split('\n');
            foreach (string cookieRow in cookieRows)
            {
                if (string.IsNullOrEmpty(cookieRow))
                {
                    continue;
                }
                string[] cookieArray = cookieRow.Split('^');
                if (cookieArray.Length != 5)
                {
                    throw new FormatException("cookie格式错误");
                }

                Cookie cookie = new Cookie()
                {
                    Name = cookieArray[0],
                    Value = cookieArray[1],
                    Domain = cookieArray[2],
                    Path = cookieArray[3],
                    Expires = Convert.ToDateTime(cookieArray[4]),
                    HttpOnly = true
                };
                cc.Add(cookie);
            }
            return cc;
        }
    }
}
