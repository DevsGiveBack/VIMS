﻿using System;
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
        [HttpGet]
        public ActionResult VolunteerLookUp(int locationId)
        {
            Location location = lookUpRepository.GetLocationById(locationId);

            VolunteerLookUpViewModel vm = new VolunteerLookUpViewModel();
            vm.LocationId = location.LocationId;
            vm.LocationName = location.LocationName;

            return View(vm);
        }
           
        /// <summary>
        /// VolunteerLookUpNext: volunteer pressed next 
        /// </summary>
        /// <param name="model">TimeClockInViewModel</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VolunteerLookUp(int locationId, string userName)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login", "AccountController");
            }

            VolunteerInfo volunteer = volunteerInfoRepository.GetVolunteer(userName);
                      
            if (volunteer != null && volunteer.VolunteerId > 0)
            {
                ViewBag.LocationId = locationId;
                ViewBag.UserName = userName;
                ViewBag.VolunteerId = volunteer.VolunteerId;

                return View("VolunteerPhotoCapture");
            }

            return RedirectToAction("VolunteerLookUp", "VolunteerClockTime", new { locationId = locationId });
        }
        
        //PhotoCaptured
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VolunteerClockIn(int locationId, string userName)
        {
            VolunteerInfo volunteer = volunteerInfoRepository.GetVolunteer(userName);
            Location location = lookUpRepository.GetLocationById((int)locationId);

            if (volunteer != null && volunteer.VolunteerId > 0)
            {
                VolunteerProfileInfo profile =
                   volunteerInfoRepository.GetLastProfileInfo(volunteer.VolunteerId);
                VolunteerClockInOutInfo clockInfo = volunteerInfoRepository.GetClockedInInfo(volunteer);

                //todo move to a view model?
                ViewBag.isClockedIn = (clockInfo != null); // clocked in
                ViewBag.Case = profile != null ? profile.CaseNumber : "NA";

                TempData["VolunteerInfo"] = volunteer;
                TempData["Location"] = location;

                //dispose now, new context will be created in next request 
                volunteerInfoRepository.Dispose();

                VolunteerClockInViewModel vm = new VolunteerClockInViewModel();
                vm.Volunteer = volunteer;
                vm.LocationId = location.LocationId;
                vm.LocationName = location.LocationName;
                //vm.DefaultPhotoPath = volunteerInfoRepository.GetDefaultProfileInfo(volunteer.VolunteerId);

                return View(vm);
            }

            return RedirectToAction("VolunteerLookUp", "VolunteerClockTime", new { locationId = location.LocationId });
        }

        public ActionResult VolunteerPhotoCaptured()
        {
            //BKP todo
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "MyId1", Value = "MyId1", Selected = true });
            items.Add(new SelectListItem { Text = "MyId2", Value = "MyId2" });

            ViewBag.IdList = items;

            return View();
        }

        /// <summary>
        /// VolunteerClockedInOut: volunteer punched clock
        /// </summary>
        /// <returns>a clocked in or out view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult VolunteerClockedInOut(int locationId, string userName)
        public ActionResult VolunteerClockedInOut()
        {
            VIMSDBContext context = ((Repository<VolunteerInfo>)volunteerInfoRepository).Context;
            VolunteerInfo volunteer = (VolunteerInfo)TempData["VolunteerInfo"];
            Location location = ((Location)TempData["Location"]);
            
            context.Entry(volunteer).State = EntityState.Modified; // reload after request

            VolunteerClockInOutInfo clockInfo = volunteerInfoRepository.GetClockedInInfo(volunteer);
            VolunteerProfilePhotoInfo photo = volunteerInfoRepository.GetLastPhotoInfo(volunteer);
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
                clockIn.LocationId = location.LocationId;
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
            model.LocationId = location.LocationId;
            model.LocationName = location.LocationName; 
            model.TimeLogged = VolunteerClockedInOutViewModel.GetHoursLogged(volunteerInfoRepository.GetVolunteersCompletedInOutInfos(volunteer));
            model.RecentClockInformation = volunteerInfoRepository.GetVolunteersRecentClockInOutInfos(volunteer, Util.TJSConstants.RECENT_LIST_LEN);
            model.CaseNumber = profile != null ? profile.CaseNumber : "NA";
            model.TimeNeeded = profile != null ? new TimeSpan((short)profile.Volunteer_Hours_Needed, 0, 0) : new TimeSpan(0, 0, 0);

            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult VolunteerAllReadyClockedIn(int locationId, int userId)
        {
            // build model for view
            VolunteerAllReadyClockedInViewModel model = new VolunteerAllReadyClockedInViewModel();
            Location location = lookUpRepository.GetLocationById(locationId);
            model.LocationId = locationId;
            model.LocationName = location.LocationName;
            model.UserId = userId;
            model.OrganizationName = lookUpRepository.GetOrganizationById((int)location.OrganizationId).OrganizationName;

            return View(model);
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
        public void Capture(int id)
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
            VolunteerInfo volunteer = volunteerInfoRepository.GetVolunteerById(id);
            VolunteerProfilePhotoInfo photo = new VolunteerProfilePhotoInfo();
            photo.VolunteerProfilePhotoPath = name;
            photo.CreatedDt = DateTime.Now;

            volunteer.VolunteerProfilePhotoInfoes.Add(photo);
            context.SaveChanges(); //BKP todo, merge with repo code
        }
    }
}