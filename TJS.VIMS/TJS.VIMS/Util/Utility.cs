using System;
using System.Collections.Generic;
using TJS.VIMS.Models;

namespace TJS.VIMS.Util
{
    public static class Utility
    {
        ///// <summary>
        ///// gets a time span for shift in hours & minutes
        ///// </summary>
        ///// <param name="info">a VolunteerClockInOutInfo (both in and out must be present)</param>
        ///// <returns>formated string</returns>
        //public static string GetClockedInTime(VolunteerClockInOutInfo info)
        //{
        //    return GetFormatedTimeSpan(info.ClockInDateTime.Value, info.ClockOutDateTime.Value);
        //}

        //public static string GetTotalHours(List<VolunteerClockInOutInfo> infos)
        //{
        //    //foreach()
        //    return GetFormatedTimeSpan(new TimeSpan(0, 0, 0));
        //}

        //public static string GetRemainingHours(List<VolunteerClockInOutInfo> infos)
        //{
        //    return GetFormatedTimeSpan(new TimeSpan(0, 0, 0));
        //}

        //public static string GetFormatedTimeSpan(DateTime start, DateTime end)
        //{
        //    TimeSpan span = end.Subtract(start);
        //    return GetFormatedTimeSpan(span);
        //}

        //public static string GetFormatedTimeSpan(TimeSpan span)
        //{
        //    int total = (int)Math.Ceiling(span.TotalMinutes);
        //    return GetFormatedTimeSpan(total);
        //}

        //public static string GetFormatedTimeSpan(int total)
        //{
        //    int hours = (int)Math.Floor(total / 60d);
        //    int minutes = total % 60;
        //    return string.Format("{0} hours {1} minutes", hours, minutes);
        //}

        /// <summary>
        /// convert hex string to bytes
        /// </summary>
        /// <param name="str">string of hex</param>
        /// <returns>byte array</returns>
        public static byte[] HexToBytes(string str)
        {
            int len = (str.Length) / 2;
            byte[] bytes = new byte[len];

            for (int i = 0; i < len; ++i)
            {
                bytes[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
    }
}