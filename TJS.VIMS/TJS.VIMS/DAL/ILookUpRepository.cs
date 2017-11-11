using System;
using System.Collections.Generic;
using TJS.VIMS.Models;

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
