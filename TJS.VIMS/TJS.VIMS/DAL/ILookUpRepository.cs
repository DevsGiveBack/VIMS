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
        List<Location> GetLocation();
        Location GetLocationById(int locationId);
        List<Country> GetCountry();
        List<State> GetState();
    }
}
