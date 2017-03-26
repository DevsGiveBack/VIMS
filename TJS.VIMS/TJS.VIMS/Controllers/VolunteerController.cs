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
            List<State> lsState;
            List<Location> lsLocation;

            if (lookUpRepository != null)
            {
                lsState = lookUpRepository.GetState();
                lsLocation = lookUpRepository.GetLocation();
            }
            else
            {
                lsState = new List<State>();
                lsLocation = new List<Location>();
            }

            return View(new VolunteerViewModel(lsLocation));
        }
    }
}