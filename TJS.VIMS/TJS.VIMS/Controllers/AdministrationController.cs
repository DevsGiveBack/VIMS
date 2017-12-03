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
        public ActionResult Start(long adminId)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateOrganization(long admin)
        {
            ViewBag.AdminId = admin;
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrganization(long admin, Organization organization)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    organization.Active = true;
                    organization.CreatedBy = admin;
                    organization.CreatedDt = System.DateTime.Now;
                    context.Organizations.Add(organization);
                    context.SaveChanges();
                }
                return View("CreateOrganizationConfirmation", organization);
            }
            return View("Error");
        }

        [HttpGet] 
        public ActionResult EditOrganization(long admin, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Organization organization = context.Organizations.Find(id);
                if (organization != null && (bool)organization.Active) // BKP fix should not be nullable
                    return View("EditOrganization", organization);
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult EditOrganization(long admin, Organization organization)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    organization.UpdatedBy = admin; 
                    organization.UpdatedDt = System.DateTime.Now;
                    Organization o = context.Organizations.Find(organization.Id);
                    if (organization != null && (bool)organization.Active) // BKP fix should not be nullable
                    {
                        context.Entry(o).CurrentValues.SetValues(organization);
                        context.SaveChanges();
                        return View("EditOrganizationConfirmation", organization);
                    }
                }
            }
            return View("Error");
        }

        public ActionResult UndoEditOrganization(Organization organization)
        {
            return null; // todo
        }

        [HttpGet]
        public ActionResult DeleteOrganization(long admin, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Organization organization = context.Organizations.Find(id);
                if (organization != null && (bool)organization.Active)
                {
                    organization.Active = false;
                    organization.UpdatedBy = admin; 
                    organization.UpdatedDt = DateTime.Now;
                    context.SaveChanges();
                    return View("DeleteOrganizationConfirmation");
                }
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult UndoDeleteOrganization(long admin, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Organization organization = context.Organizations.Find(id);
                if (organization != null && !(bool)organization.Active)
                {
                    organization.Active = true;
                    organization.UpdatedBy = admin; 
                    organization.UpdatedDt = DateTime.Now;
                    context.SaveChanges();
                    return View("UndoDeleteOrganizationConfirmation");
                }
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult CreateEmployee(long admin)
        {
            ViewBag.AdminId = admin;
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
            return View("Error");
        }

        [HttpGet]
        public ActionResult EditEmployee(long admin, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Employee employee = context.Employees.Find(id);
                if(employee != null)
                    return View("EditEmployee", employee);
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult EditEmployee(long admin, Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    employee.UpdatedBy = admin;
                    employee.UpdatedDt = System.DateTime.Now;
                    Employee e = context.Employees.Find(employee.Id);
                    context.Entry(e).CurrentValues.SetValues(employee);
                    context.SaveChanges();
                }
                return View("EditEmployeeConfirmation", employee);
            }
            return View("Error");
        }

        public ActionResult UndoEditEmployee(Employee employee)
        {
            return null; // todo
        }

        [HttpGet]
        public ActionResult DeleteEmployee(long admin, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Employee employee = context.Employees.Find(id);
                if (employee != null && employee.Active != false)
                {
                    employee.Active = false; // just set to not active
                    employee.UpdatedBy = admin;  
                    employee.UpdatedDt = System.DateTime.Now;
                    context.SaveChanges();
                    return View("DeleteEmployeeConfirmation", employee);
                }
                return View("Error");
            }
        }

        public ActionResult UndoDeleteEmployee(long admin, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Employee employee = context.Employees.Find(id);
                if (employee != null && employee.Active != true)
                {
                    employee.Active = true; // just set to active
                    employee.UpdatedBy = admin;  
                    employee.UpdatedDt = System.DateTime.Now;
                    context.SaveChanges();
                    return View("UndoDeleteEmployeeConfirmation");
                }
            }
            return View("Error");
        }

        //todo...

        [HttpGet]
        public ActionResult VolunteerInformation(long admin, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                VolunteerInfo volunteer = context.VolunteerInfoes.Find(id);
                if(volunteer != null)
                    return View("VolunteerInformation", volunteer);
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult VolunteerInformation(VolunteerInfo volunteer)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    VolunteerInfo info = context.VolunteerInfoes.Find(volunteer.Id);
                    if (info != null)
                    {
                        context.Entry(info).CurrentValues.SetValues(volunteer);
                        context.SaveChanges();
                        return View("VolunteerInformationConfirmation");
                    }
                }
            }
            return View("Error");
        }

        /// <summary>
        /// time clock activity
        /// </summary>
        /// <returns></returns>
        public ActionResult TimeClockActivity()
        {
            // todo
            return View();
        }

        /// <summary>
        /// activity of single volunteer
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        public ActionResult TimeClockActivity(VolunteerInfo volunteer)
        {
            // todo
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        public ActionResult NoShows(VolunteerInfo volunteer)
        {
            // todo
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult VolunteersReport()
        {
            // todo
            return View();
        }

        public ActionResult ForgotPassword()
        {
            //todo
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