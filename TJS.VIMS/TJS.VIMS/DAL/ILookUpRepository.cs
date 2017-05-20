using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJS.VIMS.Models;

namespace TJS.VIMS.DAL
{
    public interface ILookUpRepository : IDisposable
    {
        List<Location> GetLocations();
        Location GetLocationById(int locationId);
        Organization GetOrganizationById(int organizationId);
        List<Country> GetCountries();
        List<State> GetStates();
    }
}
