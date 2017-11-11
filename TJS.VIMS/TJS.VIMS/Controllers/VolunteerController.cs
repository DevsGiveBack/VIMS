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
    }
}