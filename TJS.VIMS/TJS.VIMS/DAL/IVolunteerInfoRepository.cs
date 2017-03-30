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
        VolunteerProfileInfo GetLastProfileInfo(long vid);
        List<VolunteerClockInOutInfo> GetVolunteersRecentClockInOutInfos(VolunteerInfo volunteer, int n);
        List<VolunteerClockInOutInfo> GetVolunteersCompletedInOutInfos(VolunteerInfo volunteer);
        //string GetFormatedClockedInTime(VolunteerClockInOutInfo info);
        //string GetFormatedHoursLogged(VolunteerInfo volunteer);
        void Save();
    }
}