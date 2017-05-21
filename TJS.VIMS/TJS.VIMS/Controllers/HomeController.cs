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

        [HttpGet]
        public ActionResult EditLocation(int locationId)
        {
            EditLocationsViewModel vm = new EditLocationsViewModel();
            vm.countries = lookUpRepository.GetCountries();
            vm.states = lookUpRepository.GetStates();
            vm.Location = lookUpRepository.GetLocationById(locationId);
            return View("EditLocation", vm);
        }

        [HttpPost]
        public ActionResult EditLocation(EditLocationsViewModel model)
        {
            if (ModelState.IsValid)
            {
                LocationRepository repo = new LocationRepository(new VIMSDBContext());
                Location location = repo.Get(model.Location.LocationId);
                location.LocationName = model.Location.LocationName;

                repo.Context.Entry(location).State = System.Data.Entity.EntityState.Modified;
                repo.Save();
                repo.Dispose();

                return RedirectToAction("Location");
            }
            return View(model.Location);
        }

        [HttpGet]
        public ActionResult DeleteLocation(int locationId)
        {
            Location location = lookUpRepository.GetLocationById(locationId);
            VIMSDBContext context = ((LookUpRepository)lookUpRepository).Context;
            context.Locations.Remove(location);
            context.SaveChanges();

            return View();
        }

        [HttpPost]
        public ActionResult DeleteLocation(Location location)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
   
    }
}