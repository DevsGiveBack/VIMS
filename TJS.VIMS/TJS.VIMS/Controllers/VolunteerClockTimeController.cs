using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Web.Mvc;
using TJS.VIMS.DAL;
using TJS.VIMS.Models;
using TJS.VIMS.ViewModel;

namespace TJS.VIMS.Controllers
{
    //[Authorize]
    public class VolunteerClockTimeController : Controller
    {
        private IEmployeeRepository employeeRepository;
        private ILookUpRepository lookUpRepository;
        private IVolunteerInfoRepository volunteerInfoRepository;

        public VolunteerClockTimeController(IEmployeeRepository employeeRepository, ILookUpRepository lookUpRepository, IVolunteerInfoRepository volunteerInfoRepository)
        {
            this.employeeRepository = employeeRepository;
            this.lookUpRepository = lookUpRepository;
            this.volunteerInfoRepository = volunteerInfoRepository;
        }

        public VolunteerClockTimeController()
        {
        }

        /// <summary>
        /// VolunteerLookUp: opens the volunteer lookup view
        /// </summary>
        /// <param name="id">a location id</param>
        /// <returns>an ActionResult</returns>
        //[Authorize]
        public ActionResult VolunteerLookUp(int id)
        {
            Location location = lookUpRepository.GetLocationById(id);

            VolunteerLookUpViewModel view_model = new VolunteerLookUpViewModel(location.LocationId.ToString(), location.LocationName);
            //view_model.Employee = null;
            //view_model.Location = location;
            
            return View(view_model);
        }

        /// <summary>
        /// VolunteerLookUpNext: volunteer pressed next 
        /// </summary>
        /// <param name="model">TimeClockInViewModel</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VolunteerLookUpNext(VolunteerLookUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("VolunteerLookUp", model);
            }

            VolunteerInfo volunteer = volunteerInfoRepository.GetVolunteer(model.UserName);

            if (volunteer != null && volunteer.VolunteerId > 0)
            {
                VolunteerProfileInfo profile = 
                    volunteerInfoRepository.GetLastProfileInfo(volunteer.VolunteerId);
                VolunteerClockInOutInfo clockInfo = volunteerInfoRepository.GetClockedInInfo(volunteer);

                // move to view model?
                ViewBag.isClockedIn = (clockInfo != null); // clocked in
                ViewBag.Case = profile != null ? profile.CaseNumber : "NA";
                
                TempData["VolunteerInfo"] = volunteer;
                TempData["VolunteerLookUpViewModel"] = model; 

                //BKP dispose now, new context will be created in next request 
                volunteerInfoRepository.Dispose();

                VolunteerClockInViewModel view_model = new VolunteerClockInViewModel();
                //view_model.Location = model.Location;
                //view_model.Employee = model.Employee;
                view_model.Volunteer = volunteer;
                view_model.LocationId = model.LocationId;
                
                return View("VolunteerClockIn", view_model);
            }

            return View("VolunteerLookUp", model);
        }

        /// <summary>
        /// VolunteerClockedInOut: volunteer punched clock
        /// </summary>
        /// <returns>a clocked in or out view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VolunteerClockedInOut()
        {
            VIMSDBContext context = ((Repository<VolunteerInfo>)volunteerInfoRepository).Context;
            VolunteerInfo volunteer = (VolunteerInfo)TempData["VolunteerInfo"];
            int locationId = ((VolunteerLookUpViewModel)TempData["VolunteerLookUpViewModel"]).LocationId;
            context.Entry(volunteer).State = EntityState.Modified; // reload after request

            VolunteerClockInOutInfo clockInfo = volunteerInfoRepository.GetClockedInInfo(volunteer);
            VolunteerProfilePhotoInfo photo = volunteerInfoRepository.GetPhotoInfo(volunteer);
            VolunteerProfileInfo profile = volunteerInfoRepository.GetDefaultProfileInfo(volunteer.VolunteerId);
            
            if (clockInfo != null)
            {
                // was clocked in so clock out
                clockInfo.ClockOutDateTime = DateTime.Now;
                clockInfo.ClockOutProfilePhotoPath =
                    photo != null ? photo.VolunteerProfilePhotoPath : null;
                context.SaveChanges(); //BKP todo, merge with repo code
            }
            else
            {
                // clock in 
                VolunteerClockInOutInfo clockIn = new VolunteerClockInOutInfo();
                clockIn.VolunteerProfileInfo = profile;
                clockIn.LocationId = locationId;
                clockIn.ClockInDateTime = DateTime.Now;
                clockIn.ClockInOutLocationId = ViewBag.LocationId;
                clockIn.ClockInProfilePhotoPath =
                    photo != null ? photo.VolunteerProfilePhotoPath : null;
                clockIn.CreatedBy = null; 
                clockIn.CreatedDt = DateTime.Now;
                volunteer.VolunteerClockInOutInfoes.Add(clockIn);
                context.SaveChanges(); //BKP todo, merge with repo code
            }
                
            // build model for view
            VolunteerClockedInOutViewModel model = new VolunteerClockedInOutViewModel();
            model.isClockedIn = (clockInfo == null); // now!, clocked in
            model.Volunteer = volunteer;
            model.LocationId = locationId;
            model.TimeLogged = VolunteerClockedInOutViewModel.GetHoursLogged(volunteerInfoRepository.GetVolunteersCompletedInOutInfos(volunteer));
            model.RecentClockInformation = volunteerInfoRepository.GetVolunteersRecentClockInOutInfos(volunteer, Util.TJSConstants.RECENT_LIST_LEN);
            model.CaseNumber = profile != null ? profile.CaseNumber : "NA";
            model.TimeNeeded = profile != null ? new TimeSpan((short)profile.Volunteer_Hours_Needed, 0, 0) : new TimeSpan(0, 0, 0);

            return View(model);
        }

        public ActionResult VolunteerAllReadyClockedIn(int locationId, int userId)
        {
            //BKP todo create a view model here
            ViewBag.locationId = locationId;
            Location location = lookUpRepository.GetLocationById(locationId);
            ViewBag.Location = location;
            ViewBag.Organization = lookUpRepository.GetOrganizationById((int)location.OrganizationId);
            ViewBag.UserId = userId;
            return View();
        }

        public ActionResult VolunteerCreateAccount()
        {
            //todo
            return View();
        }

        /// <summary>
        /// Capture: capture action for webcam 
        /// </summary>
        /// <param name="user">user name</param>
        [HttpPost]
        public void Capture(string user)
        {
            var stream = Request.InputStream;
            string dump = string.Empty;

            using (var reader = new StreamReader(stream))
                dump = reader.ReadToEnd();

            //create a unique name save to ViewData
            string name = Guid.NewGuid().ToString("N") + ".jpg"; //BKP can I be sure is always a jpeg?

            var path = Server.MapPath("~/Capture/" + name);
            System.IO.File.WriteAllBytes(path, Util.Utility.HexToBytes(dump));

            DbContext context = ((Repository<VolunteerInfo>)volunteerInfoRepository).Context;
            VolunteerInfo volunteer = volunteerInfoRepository.GetVolunteer(user);
            VolunteerProfilePhotoInfo photo = new VolunteerProfilePhotoInfo();
            photo.VolunteerProfilePhotoPath = name;
            photo.CreatedDt = DateTime.Now;

            volunteer.VolunteerProfilePhotoInfoes.Add(photo);
            context.SaveChanges(); //BKP todo, merge with repo code
        }
    }
}