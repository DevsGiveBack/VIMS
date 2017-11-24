using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJS.VIMS.ViewModel;
using TJS.VIMS.Models;
using TJS.VIMS.DAL;

namespace TJS.VIMS.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index(int? id)
        {
            if (id == null)
                id = Properties.Settings.Default.OrganizationId;

            return RedirectToAction("Login", "Account", new { organizationId = id });
        }

        [Authorize]
        public ActionResult Location()
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                List<Location> locations = context.Locations.ToList<Location>();
                return View(new LocationViewModel(locations));
            }
        }

        [HttpPost]      
        [ValidateAntiForgeryToken]
        public ActionResult Location(LocationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("VolunteerLookUp", "VolunteerClockTime", new { locationId = model.SelectedLocationId } );
        }

        [HttpGet]
        public ActionResult AddLocation()
        {
            EditLocationsViewModel vm = new EditLocationsViewModel();
            using (VIMSDBContext context = new VIMSDBContext())
            {
                vm.countries = context.Countries.ToList<Country>(); 
                vm.states = context.States.ToList<State>();
                vm.Location = new Location();
            }

            return View("AddLocation", vm);
        }

        [HttpPost]
        public ActionResult AddLocation(EditLocationsViewModel model)
        {
            if (ModelState.IsValid) 
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    //todo
                    model.Location.CreatedBy = 0;
                    model.Location.CreatedDt = System.DateTime.Now;
                    context.Locations.Add(model.Location);
                    context.SaveChanges();
                }

                return RedirectToAction("Location");
            }
            return View(model.Location);
        }

        [HttpPost]
        public ActionResult EditLocation(LocationViewModel model)
        {
            EditLocationsViewModel vm = new EditLocationsViewModel();
            using (VIMSDBContext context = new VIMSDBContext())
            {
                vm.countries = context.Countries.ToList<Country>();
                vm.states = context.States.ToList<State>();
                vm.Location = context.Locations.Find(model.SelectedLocationId);
            }

            return View("EditLocation", vm);
        }

        [HttpPost]
        public ActionResult UpdateLocation(EditLocationsViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    //todo
                    //model.Location.UpdatedBy = "0";
                    //model.Location.UpdatedDt = System.DateTime.Now;
                    Location location = context.Locations.Find(model.Location.LocationId);
                    context.Entry(location).CurrentValues.SetValues(model.Location);
                    context.SaveChanges();
                }

                
            }
            return View(model.Location);
        }

        [HttpPost]
        public ActionResult DeleteLocation(LocationViewModel model)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Location location = context.Locations.Find(model.SelectedLocationId);
                context.Locations.Remove(location);
                context.SaveChanges();
            }

            return RedirectToAction("Location");
            //return View(location);
        }
    }
}