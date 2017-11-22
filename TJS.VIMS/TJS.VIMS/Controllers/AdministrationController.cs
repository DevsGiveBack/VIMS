using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TJS.VIMS.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddOrganization()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditOrganization()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteOrganization()
        {
            return View();
        }
    }
}