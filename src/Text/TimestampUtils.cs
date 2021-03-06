using System;

namespace JiuLing.CommonLibs.Text
{
    /// <summary>
    /// 时间戳帮助类
    /// </summary>
    public class TimestampUtils
    {
        /// <summary>
        /// 获取一个10位的时间戳
        /// </summary>
        /// <returns></returns>
        public static Int64 GetLen10()
        {
            DateTimeOffset dto = new DateTimeOffset(DateTime.Now);
            return dto.ToUnixTimeSeconds();
        }

        /// <summary>
        /// 获取一个13位的时间戳
        /// </summary>
        /// <returns></returns>
        public static Int64 GetLen13()
        {
            DateTimeOffset dto = new DateTimeOffset(DateTime.Now);
            return dto.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// 生成一个10位的时间戳
        /// </summary>
        /// <param name="time">要转换的时间</param>
        /// <returns></returns>
        public static Int64 ConvertToLen10(DateTime time)
        {
            DateTimeOffset dto = new DateTimeOffset(time);
            return dto.ToUnixTimeSeconds();
        }

        /// <summary>
        /// 生成一个13位的时间戳
        /// </summary>
        /// <param name="time">要转换的时间</param>
        /// <returns></returns>
        public static Int64 ConvertToLen13(DateTime time)
        {
            DateTimeOffset dto = new DateTimeOffset(time);
            return dto.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// 时间戳转为DateTime
        /// </summary>
        /// <param name="timeStamp">时间戳，支持10位、13位两种格式</param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(Int64 timeStamp)
        {
            DateTimeOffset dateTimeOffset;
            switch (timeStamp.ToString().Length)
            {
                case 10:
                    dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timeStamp);
                    return dateTimeOffset.ToLocalTime().DateTime;
                case 13:
                    dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(timeStamp);
                    return dateTimeOffset.ToLocalTime().DateTime;
                default:
                    throw new ArgumentException("时间戳格式不正确");
            }

        }
    }
}
