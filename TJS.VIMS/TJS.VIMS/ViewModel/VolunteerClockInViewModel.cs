using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJS.VIMS.Models;

namespace TJS.VIMS.ViewModel
{
    public class VolunteerClockInViewModel : AuthorizedViewModel
    {
        /// <summary>
        /// the volunteer info
        /// </summary>
        public Volunteer Volunteer { get; set; }
        public string DefaultPhotoPath { get; set; }
    }
}