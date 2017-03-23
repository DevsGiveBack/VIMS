using System;
using System.Linq;
using TJS.VIMS.Models;


namespace TJS.VIMS.DAL
{
    public class VolunteerInfoRepository : IVolunteerInfoRepository, IDisposable
    {
        private VIMSDBContext vimsDBContext = null;
        private bool disposed = false;

        public VIMSDBContext Context { get { return vimsDBContext; } }

        public VolunteerInfoRepository(VIMSDBContext vimsDBContext)
        {
            this.vimsDBContext = vimsDBContext;
        }

        public VolunteerInfo GetVolunteer(string userName)
        {
            return vimsDBContext.VolunteerInfoes
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

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    vimsDBContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}