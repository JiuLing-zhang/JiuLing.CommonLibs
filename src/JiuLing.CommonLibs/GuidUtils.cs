using System;

namespace JiuLing.CommonLibs
{

    /// <summary>
    /// Guid工具类
    /// </summary>
    public class GuidUtils
    {
        /// <summary>
        /// 获取一个Guid，格式：9af7f46a-ea52-4aa3-b8c3-9fd484c2af12
        /// </summary>
        /// <returns></returns>
        public static string GetFormatDefault()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 获取一个Guid，格式：e0a953c3ee6040eaa9fae2b667060e09
        /// </summary>
        /// <returns></returns>
        public static string GetFormatN()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 获取一个Guid，格式：9af7f46a-ea52-4aa3-b8c3-9fd484c2af12
        /// </summary>
        /// <returns></returns>
        public static string GetFormatD()
        {
            return Guid.NewGuid().ToString("D");
        }

        /// <summary>
        /// 获取一个Guid，格式：{734fd453-a4f8-4c5d-9c98-3fe2d7079760}
        /// </summary>
        /// <returns></returns>
        public static string GetFormatB()
        {
            return Guid.NewGuid().ToString("B");
        }

        /// <summary>
        /// 获取一个Guid，格式：(ade24d16-db0f-40af-8794-1e08e2040df3)
        /// </summary>
        /// <returns></returns>
        public static string GetFormatP()
        {
            return Guid.NewGuid().ToString("P");
        }

        /// <summary>
        /// 获取一个Guid，格式：{0x3fa412e3,0x8356,0x428f,{0xaa,0x34,0xb7,0x40,0xda,0xaf,0x45,0x6f}}
        /// </summary>
        /// <returns></returns>
        public static string GetFormatX()
        {
            return Guid.NewGuid().ToString("X");
        }
    }
}
