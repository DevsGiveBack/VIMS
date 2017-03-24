using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJS.VIMS.Models;

namespace TJS.VIMS.DAL
{
    public interface IVolunteerInfoRepository :  IDisposable
    {
        VolunteerInfo GetVolunteer(string userName);
        VolunteerClockInOutInfo GetClockedInInfo(VolunteerInfo volunteer);
        VolunteerProfilePhotoInfo GetPhotoInfo(VolunteerInfo volunteer);
        void Save();
    }
}