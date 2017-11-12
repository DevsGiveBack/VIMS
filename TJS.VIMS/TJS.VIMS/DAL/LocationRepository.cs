using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJS.VIMS.Models;

namespace TJS.VIMS.DAL
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(VIMSDBContext context) : base(context)
        {
        }
    }
}