using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJS.VIMS.Models;

namespace TJS.VIMS.ViewModel
{
    public class VolunteerClockedInOutViewModel
    {
        public VolunteerInfo Volunteer { get; set; }

        public string Name { get; set; }

        public string CaseNumber { get; set; }

        public int HoursNeeded { get; set; }

        public int TotalHoursLogged { get; set; }

        public int RemainingHours { get; set; }

        public List<VolunteerClockInOutInfo> RecentClockInformation { get; set; }

        public string Location { get; set; }
    }
}