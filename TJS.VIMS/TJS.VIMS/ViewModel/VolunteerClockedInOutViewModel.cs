using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJS.VIMS.Models;
using TJS.VIMS.Util;

namespace TJS.VIMS.ViewModel
{
    public class VolunteerClockedInOutViewModel : AuthorizedViewModel
    {

        /// <summary>
        /// returns true if volunteer is clocked-in otherwise false
        /// </summary>
        public bool isClockingIn { get; set; }

        /// <summary>
        /// the volunteer info
        /// </summary>
        public VolunteerInfo Volunteer { get; set; }

        /// <summary>
        /// case number of volunteer
        /// </summary>
        public string CaseNumber { get; set; }

        /// <summary>
        /// time needed
        /// </summary>
        public TimeSpan TimeNeeded { get; set; }

        /// <summary>
        /// time logged 
        /// </summary>
        public TimeSpan TimeLogged { get; set; }

        /// <summary>
        /// gets recent clock info
        /// </summary>
        public List<VolunteerClockInOutInfo> RecentClockInformation { get; set; }

        /// <summary>
        /// remaining time
        /// </summary>
        public TimeSpan RemainingTime
        {
            get
            {
                int minutes = (int)(Math. Round(TimeNeeded.TotalMinutes) - Math.Round(TimeLogged.TotalMinutes));
                return minutes < 0 ? new TimeSpan(0, 0, 0) : new TimeSpan(0, minutes, 0);
            }
        }

        public int PercentComplete
        {
            get
            {
                int completed = (int)Math.Round(TimeLogged.TotalMinutes / TimeNeeded.TotalMinutes * 100d);
                return completed < 100 ? completed : 100;
            }
        }

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
                minutes += (int)Math.Ceiling((i.ClockOutDateTime.Value - i.ClockInDateTime.Value).TotalMinutes);
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