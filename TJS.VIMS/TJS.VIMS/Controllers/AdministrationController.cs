using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJS.VIMS.Models;
using TJS.VIMS.DAL;

namespace TJS.VIMS.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Start()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddOrganization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrganization(Organization organization)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    organization.Active = true;
                    organization.CreatedBy = 0;
                    organization.CreatedDt = System.DateTime.Now;
                    context.Organizations.Add(organization);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        [HttpGet]
        public ActionResult EditOrganization(long id)
        {
            Organization organization = null;
            using (VIMSDBContext context = new VIMSDBContext())
            {
                organization = context.Organizations.Find(id);
            }
            return View("EditOrganization", organization);
        }

        [HttpPost]
        public ActionResult EditOrganization(Employee oraganization)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    oraganization.UpdatedBy = 0;
                    oraganization.UpdatedDt = System.DateTime.Now;
                    Organization o = context.Organizations.Find(oraganization.Id);
                    context.Entry(o).CurrentValues.SetValues(oraganization);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(oraganization);
        }

        [HttpGet]
        public ActionResult DeleteOrganization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteOrganization(Organization orgnaization, bool post)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                context.Organizations.Remove(orgnaization);
                context.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    employee.Active = true;
                    employee.CreatedBy = 0;
                    employee.CreatedDt = System.DateTime.Now;
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult EditEmployee(long id)
        {
            Employee e = null;
            using (VIMSDBContext context = new VIMSDBContext())
            {
                e = context.Employees.Find(id);
            }
            return View("EditEmployee", e);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    employee.UpdatedBy = 0;
                    employee.UpdatedDt = System.DateTime.Now;
                    Employee e = context.Employees.Find(employee. Id);
                    context.Entry(e).CurrentValues.SetValues(employee);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult DeleteEmployee(Employee employee)
        {
            return View(employee);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(Employee employee, bool post)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return View();
        }
        
        // BKP look this over
        [HttpPost]
        public ActionResult DeleteEmployee(long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Employee employee = context.Employees.Find(id);
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return View();
        }

        /// <summary>
        /// time clock activity
        /// </summary>
        /// <returns></returns>
        public ActionResult TimeClockActivity()
        {
            return View();
        }

        /// <summary>
        /// activity of single volunteer
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        public ActionResult TimeClockActivity(VolunteerInfo volunteer)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        public ActionResult NoShows(VolunteerInfo volunteer)
        {
            return View();
        }

        public ActionResult VolunteersReport()
        {
            return View();
        }

        public ActionResult TestView()
        {
            return View();
        }
    }
}