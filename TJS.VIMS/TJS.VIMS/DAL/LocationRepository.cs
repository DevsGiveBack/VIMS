using System;

namespace TJS.VIMS.DAL
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(VIMSDBContext context) : base(context)
        {
        }
    }
}