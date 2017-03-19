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
            return View("VolunteerLookUp", new TimeClockInViewModel(locationId, locationName));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //BKP should be named VolunteerClockIn or VolunteerLookUp etc... ? since the time clock is already logged into
        public ActionResult VolunteerLookUpNext(TimeClockInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            VolunteerInfo objVolunteerInfo = volunteerInfoRepository.GetVolunteer(model.UserName);

            //var clock_infos = objVolunteerInfo.VolunteerClockInOutInfoes.
            //   Where(ci => ci.ClockInDateTime.Value.Date == DateTime.Today && ci.ClockOutDateTime == null)
            //   .SingleOrDefault();

            if (objVolunteerInfo != null && objVolunteerInfo.VolunteerId > 0)
            {
                TempData["VolunteerInfo"] = objVolunteerInfo;
                return RedirectToAction("VolunteerClockIn", "VolunteerClockTime");
            }
            return View("VolunteerLookUp", objVolunteerInfo);
        }

        public ActionResult VolunteerClockIn()
        {
            VolunteerInfo objVolunteerInfo = null;
            if (TempData["VolunteerInfo"] != null)
            {
               objVolunteerInfo = (VolunteerInfo)TempData["VolunteerInfo"];
            }
            //if (objVolunteerInfo == null)
            //{
            //    return RedirectToAction("TimeClockLogIn", "VolunteerClockTime");
            //}

            TempData.Keep();
            return View(objVolunteerInfo);
        }
        
        /// <summary>
        /// POST: VolunteerClockTime/VolunteerClockedInOut
        /// </summary>
        /// <param name="model">the model</param>
        /// <returns>an ActionResult</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult VolunteerClockedInOut(VolunteerInfo volunteer)
        public ActionResult VolunteerClockedInOut()
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(info);
            //}

            //BKP HACK
            //VIMSDBContext context = ((VolunteerInfoRepository)volunteerInfoRepository).Context;
            var tmp = (VolunteerInfo)TempData["VolunteerInfo"];

            VIMSDBContext context = new VIMSDBContext();
            var volunteer = context.VolunteerInfoes
                .Where(n => n.UserName == tmp.UserName)
                .FirstOrDefault();

            var clock_info = volunteer.VolunteerClockInOutInfoes.
                Where(ci => ci.ClockInDateTime.Value.Date == DateTime.Today && ci.ClockOutDateTime == null)
                .SingleOrDefault();
 
            if (clock_info != null)
            {

                // clock out
                clock_info.ClockOutDateTime = DateTime.Now;
                context.SaveChanges();

                return View("VolunteerClockedOut");
            }

            // clock in 
            VolunteerClockInOutInfo vi = new VolunteerClockInOutInfo();
            vi.ClockInDateTime = DateTime.Now;
            vi.ClockInOutLocationId = 0;
            vi.ClockInProfilePhotoPath = string.Empty;
            vi.CreatedBy = 1;
            vi.CreatedDt = DateTime.Now;
            //FK constraint?
            vi.VolunteerId = volunteer.VolunteerId;

            volunteer.VolunteerClockInOutInfoes.Add(vi);
            context.SaveChanges();

            return View("VolunteerClockedIn", volunteer);
        }
    }
}