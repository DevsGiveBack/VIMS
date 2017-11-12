using System;
using System.Collections.Generic;
using TJS.VIMS.Models;

namespace TJS.VIMS.Reports
{
    public class Reporting
    {
        /// <summary>
        /// get total hours logged
        /// </summary>
        /// <param name="infos"></param>
        /// <returns>formated string ({0} hours {1} minutes)</returns>
        public static TimeSpan GetHoursLogged(List<VolunteerClockInOutInfo> infos)
        {
            int minutes = 0;
            foreach (var i in infos)
            {
                int punch = (int)Math.Ceiling((i.ClockOutDateTime.Value - i.ClockInDateTime.Value).TotalMinutes);
                if (punch >= 1)
                    minutes += punch;
            }
            return new TimeSpan(0, minutes, 0);
        }

        public static string GetFormatedTimeSpan(DateTime start, DateTime end)
        {
            TimeSpan span = end.Subtract(start);
            return GetFormatedTimeSpan(span);
        }

        public static string GetFormatedTimeSpan(TimeSpan span)
        {
            int total = (int)Math.Ceiling(span.TotalMinutes);
            return GetFormatedTimeSpan(total);
        }

        public static string GetFormatedTimeSpan(int total)
        {
            int hours = (int)Math.Floor(total / 60d);
            int minutes = total % 60;
            return string.Format("{0} hours {1} minutes", hours, minutes);
        }
    }
}