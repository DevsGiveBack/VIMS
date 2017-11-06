using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Web.Mvc;
using TJS.VIMS.DAL;
using TJS.VIMS.Models;
using TJS.VIMS.ViewModel;
using System.Linq;


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
        [Authorize]
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
                ViewBag.VolunteerId = volunteer.VolunteerId;
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
        //[HttpGet]
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

                VolunteerClockInViewModel vm = new VolunteerClockInViewModel();
                vm.Volunteer = volunteer;
                vm.LocationId = location.LocationId;
                vm.LocationName = location.LocationName;
                VolunteerProfilePhotoInfo photo = volunteerInfoRepository.GetLastPhotoInfo(volunteer);
                if(photo != null)
                    vm.DefaultPhotoPath = volunteerInfoRepository.GetLastPhotoInfo(volunteer).VolunteerProfilePhotoPath;

                //dispose now, new context will be created in next request 
                volunteerInfoRepository.Dispose();

                return View(vm);
            }

            return RedirectToAction("VolunteerLookUp", "VolunteerClockTime", new { locationId = location.LocationId });
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

        public ActionResult VolunteerPhotoCaptured()
        {
            //BKP todo 
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "MyId1", Value = "MyId1", Selected = true });
            items.Add(new SelectListItem { Text = "MyId2", Value = "MyId2" });
            ViewBag.IdList = items;
            return View();
        }

        [HttpGet]
        public ActionResult VolunteerEditProfile(VolunteerInfo volunteer, int locationId)
        {
            ViewBag.LocationId = locationId;
            var locations = lookUpRepository.GetLocations();
            VolunteerViewModel model = new VolunteerViewModel(locations);
            model.VolunteerInfo = volunteer;
            return View("EditVolunteerProfile", model);
        }

        [HttpPost]
        public ActionResult VolunteerEditProfile(VolunteerInfo volunteer, VolunteerProfileInfo profile, int locationId)
        {
           return View();
        }


        [HttpGet]
        public ActionResult VolunteerEditAccount(int volunteerId, int locationId)
        {
            ViewBag.LocationId = locationId;
            VIMSDBContext context = new VIMSDBContext();
            VolunteerInfo info = context.VolunteerInfoes.Find(volunteerId);

            return View(info);
        }

        [HttpPost]
        public ActionResult VolunteerUpdateAccount(VolunteerInfo volunteer, int locationId)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    VolunteerInfo info = context.VolunteerInfoes.Find(volunteer.VolunteerId);
                    context.Entry(info).CurrentValues.SetValues(volunteer);
                    context.SaveChanges();
                }

                return RedirectToAction("VolunteerLookUp", "VolunteerClockTime", new { locationId = locationId });
            }

            return View("VolunteerEditAccount", volunteer);
        }

        [HttpGet]
        public ActionResult VolunteerCreateAccount(int locationId)
        {
            ViewBag.LocationId = locationId;
            return View();
        }

        [HttpPost]
        public ActionResult VolunteerCreateAccount(VolunteerInfo volunteer, int locationId)
        {
            VIMSDBContext context = new VIMSDBContext();
            var v = context.VolunteerInfoes.Where(m => m.UserName == volunteer.UserName).SingleOrDefault();
            if(v != null)
            {
                ModelState.AddModelError("UserName", "User already exist.");
            }
            else 
            {
                context.VolunteerInfoes.Add(volunteer);
                volunteer.CreatedBy = "na"; // todo
                volunteer.CreatedDt = DateTime.Now;
                volunteer.UpdatedBy = "na"; // todo
                volunteer.UpdatedDt = DateTime.Now;
                context.SaveChanges();

                return RedirectToAction("VolunteerLookUp", "VolunteerClockTime", new { locationId = locationId });
            }
                       
            ViewBag.LocationId = locationId;
            ViewBag.Error = "User already exsit! Please choose another user name.";
            return View();
        }

        /// <summary>
        /// Capture: capture action for webcam 
        /// </summary>
        /// <param name="userId">user id</param>
        [HttpPost]
        public void Capture(int userId)
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
            VolunteerInfo volunteer = volunteerInfoRepository.GetVolunteerById(userId);
            VolunteerProfilePhotoInfo photo = new VolunteerProfilePhotoInfo();
            photo.VolunteerProfilePhotoPath = name;
            photo.CreatedDt = DateTime.Now;

            volunteer.VolunteerProfilePhotoInfoes.Add(photo);
            context.SaveChanges(); //BKP todo, merge with repo code
        }
    }
}