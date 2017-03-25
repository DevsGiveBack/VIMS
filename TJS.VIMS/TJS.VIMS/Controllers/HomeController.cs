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

        public HomeController(ILookUpRepository lookUpRepo)
        {
            this.lookUpRepository = lookUpRepo;
        }

        public ActionResult Location()
        {
            List<Location> lsLocation= lookUpRepository.GetLocation();
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
            //TempData["SelectedLocationId"] = model.SelectedLocationId;
            return RedirectToAction("TimeClockLogIn", "VolunteerClockTime", new { id = model.SelectedLocationId });
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