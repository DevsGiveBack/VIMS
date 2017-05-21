using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TJS.VIMS.Models;
using TJS.VIMS.DAL;
using TJS.VIMS.ViewModel;
using TJS.VIMS.Util;

namespace TJS.VIMS.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IEmployeeRepository employeeRepository;

        public AccountController()
        {
        }

        public AccountController(IEmployeeRepository empRepository)
        {
            this.employeeRepository = empRepository;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            // BKP todo: harcoded org id
            return View(new LogInViewModel { OrganizationId = 1 });
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogInViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = employeeRepository.GetEmployee(model.UserName, model.Password);
            if (result != null && result.ActiveInd)
            {
                model.InvalidLogin = String.Empty;   
                return RedirectToAction("Location", "Home");
            }
            model.Password = string.Empty;
            model.InvalidLogin = TJSConstants.LOGIN_ERROR_MESSAGE;
            return View(model);
        }

        public ActionResult TimeClock(LogInViewModel model, string returnUrl)
        {
            return View();
        }

        public ActionResult AdminPortal(LogInViewModel model, string returnUrl)
        {
            return View();
        }
    }
}
