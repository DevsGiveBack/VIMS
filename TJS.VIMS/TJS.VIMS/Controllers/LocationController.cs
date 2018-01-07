using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using TJS.VIMS.DAL;
using TJS.VIMS.Models;
using TJS.VIMS.ViewModel;

namespace TJS.VIMS.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditLocation(EditLocationsViewModel model)
        {
            if (ModelState.IsValid)
            {
                LocationRepository repo = new LocationRepository(new VIMSDBContext());
                Location location = repo.Find((int)model.Location.Id);
                location.Name = model.Location.Name;

                repo.Context.Entry(location).State = System.Data.Entity.EntityState.Modified;
                repo.Save();
                repo.Dispose();

                return RedirectToAction("Location");
            }
            return View(model.Location);
        }
    }
}