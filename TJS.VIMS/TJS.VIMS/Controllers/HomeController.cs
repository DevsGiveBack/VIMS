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
        //private ILookUpRepository lookUpRepository;

        public HomeController()
        {
        }

        public HomeController(ILookUpRepository lookUpRepository)
        {
            //this.lookUpRepository = lookUpRepository;
        }

        public ActionResult Location()
        {
            //List<Location> lsLocation = lookUpRepository.GetLocations();
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

            //vm.countries = lookUpRepository.GetCountries();
            //vm.states = lookUpRepository.GetStates();

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
                //LocationRepository repo = new LocationRepository(new VIMSDBContext());
                //repo.Add(model.Location);
                //repo.Save();
                //repo.Dispose();

                using (VIMSDBContext context = new VIMSDBContext())
                {
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

            //vm.countries = lookUpRepository.GetCountries();
            //vm.states = lookUpRepository.GetStates();
            //vm.Location = lookUpRepository.GetLocationById(model.SelectedLocationId);

            using (VIMSDBContext context = new VIMSDBContext())
            {
                vm.countries = context.Countries.ToList<Country>();
                vm.states = context.States.ToList<State>();
                vm.Location = context.Locations.Find(model.SelectedLocationId);
            }

            return View("EditLocation", vm);
        }

        [HttpPost]
        public ActionResult EditLocation_(EditLocationsViewModel model)
        {
            if (ModelState.IsValid)
            {
                //LocationRepository repo = new LocationRepository(new VIMSDBContext());
                //Location location = repo.Find(model.Location.LocationId);
                //repo.Context.Entry(location).CurrentValues.SetValues(model.Location);
                //repo.Save();

                using (VIMSDBContext context = new VIMSDBContext())
                {
                    Location location = context.Locations.Find(model.Location.LocationId);
                    context.Entry(location).CurrentValues.SetValues(model.Location);
                    context.SaveChanges();
                }

                return RedirectToAction("Location");
            }
            return View(model.Location);
        }

        [HttpPost]
        public ActionResult DeleteLocation(LocationViewModel model)
        {
            //LocationRepository repo = new LocationRepository(new VIMSDBContext());
            //Location location = repo.Find(model.SelectedLocationId);
            //repo.Remove(location);
            //repo.Save();

            using (VIMSDBContext context = new VIMSDBContext())
            {
                Location location = context.Locations.Find(model.SelectedLocationId);
                context.Locations.Remove(location);
                context.SaveChanges();
            }

            return RedirectToAction("Location");
            //todo create confirmation view!
            //return View();
        }
    }
}