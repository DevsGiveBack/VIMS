using System;
using System.Collections.Generic;
using System.Linq;

namespace TJS.VIMS.DAL
{
    public class VolunteerInfoRepository : Repository<Volunteer>, IVolunteerInfoRepository
    {
        public VolunteerInfoRepository(VIMSDBContext context) : base(context)
        {
        }

        /// <summary>
        /// get volunteer from Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Volunteer GetVolunteerById(int Id)
        {
            //return context.VolunteerInfoes
            // .Where(volunteer => volunteer.VolunteerId == Id).SingleOrDefault();
            return SingleOrDefault(volunteer => volunteer.Id == Id);
        }

        /// <summary>
        /// get volunteer from user name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Volunteer GetVolunteer(string userName)
        {
            //return context.VolunteerInfoes
            // .Where(volunteer => volunteer.UserName.ToLower() == userName.ToLower()).SingleOrDefault();
            return SingleOrDefault(volunteer => volunteer.UserName.ToLower() == userName.ToLower());
        }

        /// <summary>
        /// gets volunteers clockin info
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns>if clocked in returns VolunteerClockInOutInfo otherwise null</returns>
        public VolunteerTimeClock GetClockedInInfo(Volunteer volunteer)
        {
            return volunteer.VolunteerTimeClocks
                 .Where(m => m.ClockIn.Value.Date == DateTime.Today && m.ClockOut == null)
                 .SingleOrDefault();
        }

        /// <summary>
        /// gets volunteers last photo info (aka default photo)
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns>if exsit in returns VolunteerProfilePhotoInfo otherwise null</returns>
        public VolunteerPhoto GetLastPhotoInfo(Volunteer volunteer)
        {
            return volunteer.VolunteerPhotoes
                .Where(m => m.CreatedDt.Value.Date == DateTime.Today)
                .OrderByDescending(m => m.CreatedDt)
                .FirstOrDefault();
        }

        /// <summary>
        /// gets volunteers default photo info
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns>if exsit in returns VolunteerProfilePhotoInfo otherwise null</returns>
        public VolunteerPhoto GetDefaultPhotoInfo(Volunteer volunteer)
        {
            return GetLastPhotoInfo(volunteer);
        }

        // one profile per oranization
        //BKP TEST
        public VolunteerProfile GetProfileInfoByOrganization(long id, long organization_id)
        {
            return context.VolunteerProfiles
                .Where(m => m.Id == id && m.OrganizationId == organization_id)
                .SingleOrDefault();
        }

        /// <summary>
        /// gets the last profile for a volunteer
        /// </summary>
        /// <param name="id">the volunterr id</param>
        /// <returns>a VolunteerProfileInfo</returns>
        public VolunteerProfile GetLastProfileInfo(long id)
        {
            return context.VolunteerProfiles
                .Where(m => m.Id == id)
                .OrderByDescending(m => m.CreatedDt)
                .FirstOrDefault();
        }

        /// <summary>
        /// gets volunteers profile photo info
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VolunteerProfile GetDefaultProfileInfo(long id)
        {
            return GetLastProfileInfo(id);
        }

        public List<VolunteerTimeClock> GetVolunteersRecentClockInOutInfos(Volunteer volunteer, int n)
        {
            return context.VolunteerTimeClocks
                .Where(m => m.VolunteerId == volunteer.Id && m.ClockOut != null)
                .OrderByDescending(m => m.CreatedDt)
                .Take(n)
                .ToList();
        }

        public List<VolunteerTimeClock> GetVolunteersCompletedInOutInfos(Volunteer volunteer)
        {
            return context.VolunteerTimeClocks
                .Where(m => m.VolunteerId == volunteer.Id && m.ClockOut != null)
                .OrderByDescending(m => m.CreatedDt)
                .ToList();
        }

        public int GetHoursLogged(Volunteer volunteer)
        {
            return GetHoursLogged( GetVolunteersCompletedInOutInfos(volunteer) );
        }

        public int GetHoursLogged(List<VolunteerTimeClock> infos)
        {
            int minutes = 0;
            foreach (var i in infos)
            {
                minutes += (int)Math.Ceiling((i.ClockOut.Value - i.ClockIn.Value).TotalMinutes);
            }
            return minutes;
        }
    }
}