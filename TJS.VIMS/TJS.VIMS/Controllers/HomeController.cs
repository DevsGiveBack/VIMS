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
        private ILookUpRepository lookUpRepository;

        public HomeController()
        {
        }

        public HomeController(ILookUpRepository lookUpRepository)
        {
            this.lookUpRepository = lookUpRepository;
        }

        public ActionResult Location()
        {
            List<Location> lsLocation = lookUpRepository.GetLocations();
            return View(new LocationViewModel(lsLocation));
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
            vm.countries = lookUpRepository.GetCountries();
            vm.states = lookUpRepository.GetStates();
            vm.Location = new Location();
            return View("AddLocation", vm);
        }

        [HttpPost]
        public ActionResult AddLocation(EditLocationsViewModel model)
        {
            if (ModelState.IsValid) 
            {
                LocationRepository repo = new LocationRepository(new VIMSDBContext());
                repo.Add(model.Location);
                repo.Save();
                repo.Dispose();

                return RedirectToAction("Location");
            }
            return View(model.Location);
        }

        [HttpPost]
        public ActionResult EditLocation(LocationViewModel model)
        {
            EditLocationsViewModel vm = new EditLocationsViewModel();
            vm.countries = lookUpRepository.GetCountries();
            vm.states = lookUpRepository.GetStates();
            vm.Location = lookUpRepository.GetLocationById(model.SelectedLocationId);
            return View("EditLocation", vm);
        }

        [HttpPost]
        public ActionResult EditLocation_(EditLocationsViewModel model)
        {
            if (ModelState.IsValid)
            {
                LocationRepository repo = new LocationRepository(new VIMSDBContext());
                Location location = repo.Find(model.Location.LocationId);
                repo.Context.Entry(location).CurrentValues.SetValues(model.Location);
                repo.Save();
                repo.Dispose();

                return RedirectToAction("Location");
            }
            return View(model.Location);
        }

        [HttpPost]
        public ActionResult DeleteLocation(LocationViewModel model)
        {
            Location location = lookUpRepository.GetLocationById(model.SelectedLocationId);
            VIMSDBContext context = ((LookUpRepository)lookUpRepository).Context;
            context.Locations.Remove(location);
            context.SaveChanges();

            return RedirectToAction("Location");
            //todo create confirmation view!
            //return View();
        }
    }
}