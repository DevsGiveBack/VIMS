using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJS.VIMS.ViewModel;
using TJS.VIMS.DAL;
using TJS.VIMS.Models;
using System.IO;

namespace TJS.VIMS.Controllers
{
    public class VolunteerClockTimeController : Controller
    {
        #region BKP DEBUG: will remove before merge
        private static int count = 0;
        private int instance = 0;
        #endregion

        private ILookUpRepository lookUpRepository;
        private IVolunteerInfoRepository volunteerInfoRepository;

        public VolunteerClockTimeController(ILookUpRepository lookUpRepo, IVolunteerInfoRepository volunteerInfoRepository)
        {
            instance = ++count;

            this.lookUpRepository = lookUpRepo;
            this.volunteerInfoRepository = volunteerInfoRepository;
        }

        public VolunteerClockTimeController()
        {
        }

        // GET: VolunteerClockTime
        public ActionResult TimeClockLogIn()
        {
            string locationId = string.Empty;
            string locationName = string.Empty;

            if (TempData["SelectedLocationId"] != null)
            {
                locationId = TempData["SelectedLocationId"].ToString();
                if (!string.IsNullOrEmpty(locationId))
                {
                    Location objLocation = lookUpRepository.GetLocationById(Convert.ToInt32(locationId));
                    locationName = objLocation.LocationName;
                }
            }
            else
            {
                //BKP hummm, good for now 
                return RedirectToAction("Location", "Home");
            }

            return View("VolunteerLookUp", new TimeClockInViewModel(locationId, locationName));
        }

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
                TempData["VolunteerInfo"] = objVolunteerInfo;
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
            //BKP HACK TODO: implement correct pattern here
            VIMSDBContext context = ((VolunteerInfoRepository)volunteerInfoRepository).Context;
            // volunteer context is expired (between request) so recreate
            VolunteerInfo volunteer = volunteerInfoRepository
                .GetVolunteer(((VolunteerInfo)TempData["VolunteerInfo"]).UserName);

            VolunteerClockInOutInfo clock_info = volunteer.VolunteerClockInOutInfoes.
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
            //BKP todo: photo/capture data
           
            volunteer.VolunteerClockInOutInfoes.Add(vi);
            context.SaveChanges();

            return View("VolunteerClockedIn", volunteer);
        }

        /// <summary>
        /// Capture: capture action for webcam 
        /// </summary>
        [HttpPost]
        public void Capture()
        {
            var stream = Request.InputStream;
            string dump = string.Empty;

            using (var reader = new StreamReader(stream))
                dump = reader.ReadToEnd();

            //create a unique name save to ViewData
            string name = Guid.NewGuid().ToString("N") + ".jpg";
           
            var path = Server.MapPath("~/capture/" + name);
            System.IO.File.WriteAllBytes(path, StringToBytes(dump));
        }

        /// <summary>
        /// convert hex string to bytes
        /// </summary>
        /// <param name="str">string of hex</param>
        /// <returns>byte array</returns>
        private byte[] StringToBytes(string str)
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