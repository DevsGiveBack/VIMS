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
        public ActionResult DeleteOrganization(long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Organization organization = context.Organizations.Find(id);
                context.Organizations.Remove(organization);
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
                return View("CreateEmployeeConfirmation", employee);
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

        public ActionResult UndoEditEmployee(Employee employee)
        {
            return CreateEmployee(employee);
        }

        [HttpGet]
        public ActionResult DeleteEmployee(long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Employee employee = context.Employees.Find(id);
                employee.Active = false; // just set to not active
                employee.UpdatedBy = 0;  // todo
                employee.UpdatedDt = System.DateTime.Now;
                context.SaveChanges();
                return View("DeleteEmployeeConfirmation", employee);
            }
        }

        public ActionResult UndoDeleteEmployee(long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Employee employee = context.Employees.Find(id);
                employee.Active = true; // just set to active
                employee.UpdatedBy = 0;  // todo
                employee.UpdatedDt = System.DateTime.Now;
                context.SaveChanges();
                return View("UndoDeleteEmployeeConfirmation");
            }
        }

        //todo...

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult VolunteersReport()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult TestView()
        {
            return View();
        }
    }
}