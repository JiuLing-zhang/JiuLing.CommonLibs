using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace JiuLing.CommonLibs.ExtensionMethods
{
    /// <summary>
    /// List的一些扩展方法
    /// </summary>
    public static class ListExtendTools
    {
        /// <summary>
        /// 将List转换为DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">数据源</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this List<T> source)
        {
            var dt = new DataTable();
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                dt.Columns.Add(prop.Name, t);
            }

            foreach (T item in source)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                dt.Rows.Add(values);
            }

            return dt;
        }

        private static Type GetCoreType(Type t)
        {
            if (t == null || !IsNullable(t))
            {
                return t;
            }

            if (t.IsValueType)
            {
                return Nullable.GetUnderlyingType(t);
            }
            return t;
        }

        private static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

    }
}
