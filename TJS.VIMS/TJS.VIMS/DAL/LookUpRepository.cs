using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJS.VIMS.Models;

namespace TJS.VIMS.DAL
{
    public class LookUpRepository : ILookUpRepository, IDisposable
    {
        private VIMSDBContext vimsDBContext;

        public LookUpRepository(VIMSDBContext vimsDBContext)
        {
            this.vimsDBContext = vimsDBContext;
        }

        public List<Location> GetLocation()
        {
            return vimsDBContext.Locations.ToList<Location>();
        }
        
        public Location GetLocationById(int locationId)
        {
            return vimsDBContext.Locations
                .Where(x => x.LocationId == locationId).SingleOrDefault();
        }

        public List<Country> GetCountry()
        {
            return vimsDBContext.Countries.ToList<Country>();
        }

        public List<State> GetState()
        {
            return vimsDBContext.States.ToList<State>();
        }

        #region Disposable method
        private bool disposed = false;
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
        #endregion
    }
}