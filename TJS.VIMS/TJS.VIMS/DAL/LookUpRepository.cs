using System;
using System.Collections.Generic;
using System.Linq;

namespace TJS.VIMS.DAL
{
    public class LookUpRepository : ILookUpRepository, IDisposable
    {
        private VIMSDBContext context;

        public VIMSDBContext Context
        {
            get { return context; }
        }

        public LookUpRepository(VIMSDBContext context)
        {
            this.context = context;
        }

        public List<Location> GetLocations()
        {
            return context.Locations.ToList<Location>();
        }

        public Location GetLocationById(int locationId)
        {
            return context.Locations
                .Where(x => x.Id == locationId).SingleOrDefault();
        }

        public List<Organization> GetOrganizations()
        {
            return context.Organizations.ToList<Organization>();
        }

        public Organization GetOrganizationById(int organizationId)
        {
            return context
                .Organizations
                .Where(obj => obj.Id == organizationId).SingleOrDefault();
        }

        public List<Country> GetCountries()
        {
            return context.Countries.ToList<Country>();
        }

        public List<State> GetStates()
        {
            return context.States.ToList<State>();
        }

        #region Disposable method
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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