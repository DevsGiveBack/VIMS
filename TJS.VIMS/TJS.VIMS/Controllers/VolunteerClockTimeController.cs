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
            context.Entry(volunteer).State = EntityState.Modified;

            VolunteerClockInOutInfo volunteerClockInfo = volunteerInfoRepository.GetClockedInInfo(volunteer);
            VolunteerProfilePhotoInfo volunteerPhotoInfo = volunteerInfoRepository.GetPhotoInfo(volunteer);
            VolunteerProfileInfo profile = volunteerInfoRepository.GetLastProfileInfo(volunteer.VolunteerId);
            List<VolunteerClockInOutInfo> recentClockInfo =
                volunteerInfoRepository.GetVolunteersLastClockInOutInfos(volunteer, 4); //BKP: harcoded "4"


            ViewBag.LocationId = ((TimeClockInViewModel)TempData["TimeClockInViewModel"]).LocationId;
            ViewBag.Case = profile != null ? profile.CaseNumber : "NA";
            ViewBag.RecentClockInfo = recentClockInfo;

            if (volunteerClockInfo != null)
            {
                // clock out
                volunteerClockInfo.ClockOutDateTime = DateTime.Now;
                volunteerClockInfo.ClockOutProfilePhotoPath =
                    volunteerPhotoInfo != null ? volunteerPhotoInfo.VolunteerProfilePhotoPath : null;
                context.SaveChanges();

                return View("VolunteerClockedOut");
            }

            // clock in 
            VolunteerClockInOutInfo vci = new VolunteerClockInOutInfo();
            vci.ClockInDateTime = DateTime.Now;
            vci.ClockInOutLocationId = ViewBag.LocationId;
            vci.ClockInProfilePhotoPath =
                volunteerPhotoInfo != null ? volunteerPhotoInfo.VolunteerProfilePhotoPath : null;
            vci.CreatedBy = 1; //BKP todo
            vci.CreatedDt = DateTime.Now;
            volunteer.VolunteerClockInOutInfoes.Add(vci);
            context.SaveChanges(); //BKP todo, merge with repo code

            return View("VolunteerClockedIn", volunteer);
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

            var path = Server.MapPath("~/capture/" + name);
            System.IO.File.WriteAllBytes(path, HexToBytes(dump));

            DbContext context = ((Repository<VolunteerInfo>)volunteerInfoRepository).Context;
            VolunteerInfo volunteer = volunteerInfoRepository.GetVolunteer(user);
            VolunteerProfilePhotoInfo photo = new VolunteerProfilePhotoInfo();
            photo.VolunteerProfilePhotoPath = name;
            photo.CreatedDt = DateTime.Now;

            volunteer.VolunteerProfilePhotoInfoes.Add(photo);
            context.SaveChanges(); //BKP todo, merge with repo code
        }

        /// <summary>
        /// convert hex string to bytes
        /// </summary>
        /// <param name="str">string of hex</param>
        /// <returns>byte array</returns>
        private byte[] HexToBytes(string str)
        {
            int len = (str.Length) / 2;
            byte[] bytes = new byte[len];

            for (int i = 0; i < len; ++i)
            {
                bytes[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
    }
}