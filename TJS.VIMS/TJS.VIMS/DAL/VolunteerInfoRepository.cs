using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJS.VIMS.Models;


namespace TJS.VIMS.DAL
{
    public class VolunteerInfoRepository : IVolunteerInfoRepository, IDisposable
    {
        private VIMSDBContext vimsDBContext;
      
        public VolunteerInfoRepository(VIMSDBContext vimsDBContext)
        {
            this.vimsDBContext = vimsDBContext;
        }

        private bool disposed = false;

        //BKP HACK todo: need to implement proper pattern here
        public VIMSDBContext Context { get { return vimsDBContext; } }

        public VolunteerInfo GetVolunteer(string userName)
        {
            return vimsDBContext.VolunteerInfoes
                .Where(x => x.UserName.ToLower() == userName.ToLower()).SingleOrDefault();
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