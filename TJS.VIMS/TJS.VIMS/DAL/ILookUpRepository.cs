using System;
using System.Collections.Generic;

namespace TJS.VIMS.DAL
{
    public interface ILookUpRepository : IDisposable
    {
        List<Location> GetLocations();
        Location GetLocationById(int locationId);
        List<Organization> GetOrganizations();
        Organization GetOrganizationById(int organizationId);
        List<Country> GetCountries();
        List<State> GetStates();
    }
}
