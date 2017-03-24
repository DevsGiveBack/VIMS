using System;
using System.Linq;
using TJS.VIMS.Models;

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
                .OrderByDescending(m => m.CreatedDt).FirstOrDefault();
        }
    }
}