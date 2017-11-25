using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJS.VIMS.Models;
using TJS.VIMS.DAL;
using TJS.VIMS.ViewModel;

namespace TJS.VIMS.Controllers
{
    public class VolunteerController : Controller
    {
        private ILookUpRepository lookUpRepository = null;

        // GET: Volunteer
        public ActionResult CreateProfile()
        {
            List<State> states;
            List<Location> locations;
            List<Organization> organizations;

            if (lookUpRepository != null)
            {
                states = lookUpRepository.GetStates();
                locations = lookUpRepository.GetLocations();
                organizations = lookUpRepository.GetOrganizations();
            }
            else
            {
                states = new List<State>();
                locations = new List<Location>();
                organizations = new List<Organization>();
            }

            return View(new VolunteerViewModel(locations, organizations));
        }

        public ActionResult DisplayAcknowledgePolicy()
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
                    VolunteerInfo info = context.VolunteerInfoes.Find(volunteer.Id);
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
            if (v != null)
            {
                ModelState.AddModelError("UserName", "User already exist.");
            }
            else
            {
                context.VolunteerInfoes.Add(volunteer);
                volunteer.CreatedBy = 0; // todo
                volunteer.CreatedDt = DateTime.Now;
                volunteer.UpdatedBy = 0; // todo
                volunteer.UpdatedDt = DateTime.Now;
                context.SaveChanges();

                return RedirectToAction("VolunteerLookUp", "VolunteerClockTime", new { locationId = locationId });
            }

            ViewBag.LocationId = locationId;
            ViewBag.Error = "User already exsit! Please choose another user name.";
            return View();
        }
    }
}