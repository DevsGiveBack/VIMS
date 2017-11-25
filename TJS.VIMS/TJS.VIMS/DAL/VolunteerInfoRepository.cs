using System;
using System.Collections.Generic;
using System.Linq;
using TJS.VIMS.Models;

namespace TJS.VIMS.DAL
{
    public class VolunteerInfoRepository : Repository<VolunteerInfo>, IVolunteerInfoRepository
    {
        public VolunteerInfoRepository(VIMSDBContext context) : base(context)
        {
        }

        /// <summary>
        /// get volunteer from Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public VolunteerInfo GetVolunteerById(int Id)
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
        public VolunteerInfo GetVolunteer(string userName)
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
        public VolunteerClockInOutInfo GetClockedInInfo(VolunteerInfo volunteer)
        {
            return volunteer.VolunteerClockInOutInfoes
                 .Where(m => m.ClockInDateTime.Value.Date == DateTime.Today && m.ClockOutDateTime == null)
                 .SingleOrDefault();
        }

        /// <summary>
        /// gets volunteers last photo info (aka default photo)
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns>if exsit in returns VolunteerProfilePhotoInfo otherwise null</returns>
        public VolunteerProfilePhotoInfo GetLastPhotoInfo(VolunteerInfo volunteer)
        {
            return volunteer.VolunteerProfilePhotoInfoes
                .Where(m => m.CreatedDt.Value.Date == DateTime.Today)
                .OrderByDescending(m => m.CreatedDt)
                .FirstOrDefault();
        }

        /// <summary>
        /// gets volunteers default photo info
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns>if exsit in returns VolunteerProfilePhotoInfo otherwise null</returns>
        public VolunteerProfilePhotoInfo GetDefaultPhotoInfo(VolunteerInfo volunteer)
        {
            return GetLastPhotoInfo(volunteer);
        }

        // one profile per oranization
        //BKP TEST
        public VolunteerProfileInfo GetProfileInfoByOrganization(long id, long organization_id)
        {
            return context.VolunteerProfileInfoes
                .Where(m => m.Id == id && m.OrganizationId == organization_id)
                .SingleOrDefault();
        }

        /// <summary>
        /// gets the last profile for a volunteer
        /// </summary>
        /// <param name="id">the volunterr id</param>
        /// <returns>a VolunteerProfileInfo</returns>
        public VolunteerProfileInfo GetLastProfileInfo(long id)
        {
            return context.VolunteerProfileInfoes
                .Where(m => m.Id == id)
                .OrderByDescending(m => m.CreatedDt)
                .FirstOrDefault();
        }

        /// <summary>
        /// gets volunteers profile photo info
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VolunteerProfileInfo GetDefaultProfileInfo(long id)
        {
            return GetLastProfileInfo(id);
        }

        public List<VolunteerClockInOutInfo> GetVolunteersRecentClockInOutInfos(VolunteerInfo volunteer, int n)
        {
            return context.VolunteerClockInOutInfoes
                .Where(m => m.Id == volunteer.Id && m.ClockOutDateTime != null)
                .OrderByDescending(m => m.CreatedDt)
                .Take(n)
                .ToList();
        }

        public List<VolunteerClockInOutInfo> GetVolunteersCompletedInOutInfos(VolunteerInfo volunteer)
        {
            return context.VolunteerClockInOutInfoes
                .Where(m => m.Id == volunteer.Id && m.ClockOutDateTime != null)
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