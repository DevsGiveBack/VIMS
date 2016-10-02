using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJS.VIMS.ViewModel;
using TJS.VIMS.DAL;
using TJS.VIMS.Models;

namespace TJS.VIMS.Controllers
{
    public class VolunteerClockTimeController : Controller
    {
        private ILookUpRepository lookUpRepository;

        public VolunteerClockTimeController(ILookUpRepository lookUpRepo)
        {
            this.lookUpRepository = lookUpRepo;
        }
        public VolunteerClockTimeController()
        {

        }
        // GET: VolunteerClockTime
        public ActionResult TimeClockLogIn()
        {
            String locationId = string.Empty;
            String locationName = string.Empty;         
            if (TempData["SelectedLocationId"] != null)
            {
                locationId = TempData["SelectedLocationId"].ToString();
                if (!string.IsNullOrEmpty(locationId))
                {
                    Location objLocation=lookUpRepository.GetLocationById(Convert.ToInt32(locationId));
                    locationName=objLocation.LocationName;
                }
            }
            return View(new TimeClockInViewModel(locationId, locationName));
        }
    }
}