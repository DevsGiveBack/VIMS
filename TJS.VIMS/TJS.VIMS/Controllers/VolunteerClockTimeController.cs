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
        private IVolunteerInfoRepository volunteerInfoRepository;

        public VolunteerClockTimeController(ILookUpRepository lookUpRepo, IVolunteerInfoRepository volunteerInfoRepository)
        {
            this.lookUpRepository = lookUpRepo;
            this.volunteerInfoRepository = volunteerInfoRepository;
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
                    Location objLocation = lookUpRepository.GetLocationById(Convert.ToInt32(locationId));
                    locationName = objLocation.LocationName;
                }
            }
            return View(new TimeClockInViewModel(locationId, locationName));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TimeClockLogIn(TimeClockInViewModel model)
        {
            if (!ModelState.IsValid)
            { 
                return View(model);
            }
            VolunteerInfo objVolunteerInfo = volunteerInfoRepository.GetVolunteer(model.UserName);

            if (objVolunteerInfo != null && objVolunteerInfo.VolunteerId > 0)
            {
                TempData["VolunteerInfo"] = objVolunteerInfo;
                return RedirectToAction("VolunteerClockIn", "VolunteerClockTime");
            }
            return View(objVolunteerInfo);
        }

        public ActionResult VolunteerClockIn()
        {
            VolunteerInfo objVolunteerInfo=null;
            if (TempData["VolunteerInfo"] != null)
            {
               objVolunteerInfo = (VolunteerInfo)TempData["VolunteerInfo"];
            }
            //if (objVolunteerInfo == null)
            //{
            //    return RedirectToAction("TimeClockLogIn", "VolunteerClockTime");
            //}
            return View();
        }
    }
}