using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJS.VIMS.Models;

namespace TJS.VIMS.DAL
{
    public interface IVolunteerInfoRepository : IDisposable
    {
        VolunteerInfo GetVolunteer(string userName);
        //BKP VolunteerClockInOutInfo GetVolunteerClockInOutInfo(string userName);
    }
}