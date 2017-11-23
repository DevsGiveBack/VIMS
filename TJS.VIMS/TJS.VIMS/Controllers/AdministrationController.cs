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
                    employee.ActiveInd = true;
                    employee.CreatedBy = "0";
                    employee.CreatedDt = System.DateTime.Now;
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult EditEmployee(Employee employee)
        {
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee, bool post)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    employee.ActiveInd = true;
                    employee.UpdatedBy = "0";
                    employee.UpdatedDt = System.DateTime.Now;
                    context.Employees.Add(employee);
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
    }
}