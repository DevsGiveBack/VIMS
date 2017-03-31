using System;
using System.Collections.Generic;
using System.Linq;
using TJS.VIMS.Models;
using TJS.VIMS.Util;

namespace TJS.VIMS.DAL
{
    public class VolunteerInfoRepository : Repository<VolunteerInfo>, IVolunteerInfoRepository
    {
        public VolunteerInfoRepository(VIMSDBContext context) : base(context)
        {
        }

        public VolunteerInfo GetVolunteer(string userName)
        {
            return context.VolunteerInfoes
             .Where(x => x.UserName.ToLower() == userName.ToLower()).SingleOrDefault();
        }

        /// <summary>
        /// gets volunteers clockin info
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns>if clocked in returns VolunteerClockInOutInfo otherwise null</returns>
        public VolunteerClockInOutInfo GetClockedInInfo(VolunteerInfo volunteer)
        {
            return volunteer.VolunteerClockInOutInfoes
                 .Where(m => m.ClockInDateTime.Value.Date == DateTime.Today && m.ClockOutDateTime == null)
                 .SingleOrDefault();
        }

        /// <summary>
        /// gets volunteers photo info
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns>if exsit in returns VolunteerProfilePhotoInfo otherwise null</returns>
        public VolunteerProfilePhotoInfo GetPhotoInfo(VolunteerInfo volunteer)
        {
            return volunteer.VolunteerProfilePhotoInfoes
                .Where(m => m.CreatedDt.Value.Date == DateTime.Today)
                .OrderByDescending(m => m.CreatedDt)
                .FirstOrDefault();
        }

        /// <summary>
        /// gets the last profile for a volunteer
        /// </summary>
        /// <param name="id">the volunterr id</param>
        /// <returns>a VolunteerProfileInfo</returns>
        public VolunteerProfileInfo GetLastProfileInfo(long id)
        {
            return context.VolunteerProfileInfoes
                .Where(m => m.VolunteerId == id)
                .OrderByDescending(m => m.CreatedDt)
                .FirstOrDefault();
        }

        public VolunteerProfileInfo GetDefaultProfileInfo(long vid)
        {
            //todo
            return GetLastProfileInfo(vid);
        }

        public List<VolunteerClockInOutInfo> GetVolunteersRecentClockInOutInfos(VolunteerInfo volunteer, int n)
        {
            return context.VolunteerClockInOutInfoes
                .Where(m => m.VolunteerId == volunteer.VolunteerId && m.ClockOutDateTime != null)
                .OrderByDescending(m => m.CreatedDt)
                .Take(n)
                .ToList();
        }

        public List<VolunteerClockInOutInfo> GetVolunteersCompletedInOutInfos(VolunteerInfo volunteer)
        {
            return context.VolunteerClockInOutInfoes
                .Where(m => m.VolunteerId == volunteer.VolunteerId && m.ClockOutDateTime != null)
                .OrderByDescending(m => m.CreatedDt)
                .ToList();
        }

        public int GetHoursLogged(VolunteerInfo volunteer)
        {
            return GetHoursLogged( GetVolunteersCompletedInOutInfos(volunteer) );
        }

        public int GetHoursLogged(List<VolunteerClockInOutInfo> infos)
        {
            int minutes = 0;
            foreach (var i in infos)
            {
                minutes += (int)Math.Ceiling((i.ClockOutDateTime.Value - i.ClockInDateTime.Value).TotalMinutes);
            }
            return minutes;
        }
    }
}