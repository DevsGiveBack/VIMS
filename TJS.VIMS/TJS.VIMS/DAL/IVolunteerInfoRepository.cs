using System;
using System.Collections.Generic;

namespace TJS.VIMS.DAL
{
    public interface IVolunteerInfoRepository :  IDisposable
    {
        Volunteer GetVolunteer(string userName);
        Volunteer GetVolunteerById(int Id);
        VolunteerTimeClock GetClockedInInfo(Volunteer volunteer);
        VolunteerPhoto GetLastPhotoInfo(Volunteer volunteer);
        VolunteerProfile GetLastProfileInfo(long volunteerId);
        VolunteerProfile GetDefaultProfileInfo(long volunteerId);
        List<VolunteerTimeClock> GetVolunteersRecentClockInOutInfos(Volunteer volunteer, int n);
        List<VolunteerTimeClock> GetVolunteersCompletedInOutInfos(Volunteer volunteer);
        void Save();
    }
}