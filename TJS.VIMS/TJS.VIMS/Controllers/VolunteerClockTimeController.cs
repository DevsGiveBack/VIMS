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

        /// <summary>
        /// TimeClockLogIn: opens the volunteer lookup view
        /// </summary>
        /// <param name="id">a location id</param>
        /// <returns>an ActionResult</returns>
        //[Authorize]
        public ActionResult TimeClockLogIn(int id)
        {
            Location location = lookUpRepository.GetLocationById(id);
            return View("VolunteerLookUp", new TimeClockInViewModel(location.LocationId.ToString(), location.LocationName));
        }
        
        /// <summary>
        /// VolunteerLookUpNext: volunteer pressed next 
        /// </summary>
        /// <param name="model">TimeClockInViewModel</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VolunteerLookUpNext(TimeClockInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("VolunteerLookUp", model);
            }

            VolunteerInfo objVolunteerInfo = volunteerInfoRepository.GetVolunteer(model.UserName);

            if (objVolunteerInfo != null && objVolunteerInfo.VolunteerId > 0)
            {
                VolunteerProfileInfo profile = 
                    volunteerInfoRepository.GetLastProfileInfo(objVolunteerInfo.VolunteerId);
            
                ViewBag.Case = profile != null ? profile.CaseNumber : "NA";
                TempData["VolunteerInfo"] = objVolunteerInfo;
                TempData["TimeClockInViewModel"] = model;

                //BKP dispose now, new context will be created in next request 
                volunteerInfoRepository.Dispose();
                return View("VolunteerClockIn", objVolunteerInfo);
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
            context.Entry(volunteer).State = EntityState.Modified; // reload after request

            VolunteerClockInOutInfo clockInfo = volunteerInfoRepository.GetClockedInInfo(volunteer);
            VolunteerProfilePhotoInfo photo = volunteerInfoRepository.GetPhotoInfo(volunteer);
            VolunteerProfileInfo profile = volunteerInfoRepository.GetLastProfileInfo(volunteer.VolunteerId);
            
            if (clockInfo != null)
            {
                // clock out
                clockInfo.ClockOutDateTime = DateTime.Now;
                clockInfo.ClockOutProfilePhotoPath =
                    photo != null ? photo.VolunteerProfilePhotoPath : null;
                context.SaveChanges(); //BKP todo, merge with repo code
            }
            else
            {
                // clock in 
                VolunteerClockInOutInfo vci = new VolunteerClockInOutInfo();
                vci.VolunteerProfileInfo = profile;
                vci.ClockInDateTime = DateTime.Now;
                vci.ClockInOutLocationId = ViewBag.LocationId;
                vci.ClockInProfilePhotoPath =
                    photo != null ? photo.VolunteerProfilePhotoPath : null;
                vci.CreatedBy = 1; //BKP todo
                vci.CreatedDt = DateTime.Now;
                volunteer.VolunteerClockInOutInfoes.Add(vci);
                context.SaveChanges(); //BKP todo, merge with repo code
            }

            // build model for view
            VolunteerClockedInOutViewModel model = new VolunteerClockedInOutViewModel();
            model.isClockingIn = (clockInfo == null);
            model.Volunteer = volunteer;
            model.LocationId = ((TimeClockInViewModel)TempData["TimeClockInViewModel"]).LocationId;
            model.TimeLogged = VolunteerClockedInOutViewModel.GetHoursLogged(volunteerInfoRepository.GetVolunteersCompletedInOutInfos(volunteer));
            model.RecentClockInformation = volunteerInfoRepository.GetVolunteersRecentClockInOutInfos(volunteer, Util.TJSConstants.RECENT_LIST_LEN);
            model.CaseNumber = profile != null ? profile.CaseNumber : "NA";
            model.TimeNeeded = profile != null ? new TimeSpan((short)profile.Volunteer_Hours_Needed, 0, 0) : new TimeSpan(0, 0, 0);
            
            return View(model);
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