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
        public ActionResult Start(long admin_id)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admin_id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateOrganization(long admin_id)
        {
            ViewBag.AdminId = admin_id;
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrganization(long admin_id, Organization organization)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    organization.Active = true;
                    organization.CreatedBy = admin_id;
                    organization.CreatedDt = System.DateTime.Now;
                    context.Organizations.Add(organization);
                    context.SaveChanges();
                }
                return View("CreateOrganizationConfirmation", organization);
            }
            return View("Error");
        }

        [HttpGet] 
        public ActionResult EditOrganization(long admin_id, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Organization organization = context.Organizations.Find(id);
                if (organization != null && (bool)organization.Active) // BKP fix should not be nullable
                {
                    ViewBag.AdminId = admin_id;
                    return View("EditOrganization", organization);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult EditOrganization(long admin_id, Organization organization)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    organization.UpdatedBy = admin_id; 
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

        public ActionResult UndoEditOrganization(long admin_id, Organization organization)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    organization.Active = true;
                    organization.UpdatedBy = admin_id;
                    organization.UpdatedDt = System.DateTime.Now;
                    context.Organizations.Add(organization);
                    context.SaveChanges();
                }
                return View("UndoEditOrganizationConfirmation", organization);
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult DeleteOrganization(long admin_id, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Organization organization = context.Organizations.Find(id);
                if (organization != null && (bool)organization.Active)
                {
                    ViewBag.AdminId = admin_id;
                    ViewBag.Id = id;
                    organization.Active = false;
                    organization.UpdatedBy = admin_id;
                    organization.UpdatedDt = DateTime.Now;
                    context.SaveChanges();
                    return View("DeleteOrganizationConfirmation");
                }
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult UndoDeleteOrganization(long admin_id, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Organization organization = context.Organizations.Find(id);
                if (organization != null && !(bool)organization.Active)
                {
                    ViewBag.AdminId = admin_id;
                    ViewBag.Id = id;
                    organization.Active = true;
                    organization.UpdatedBy = admin_id;
                    organization.UpdatedDt = DateTime.Now;
                    context.SaveChanges();
                    return View("UndoDeleteOrganizationConfirmation");
                }
            }
            return View("Error");
        }
        
        [HttpGet] 
        public ActionResult CreateEmployee(long admin_id)
        {
            ViewBag.AdminId = admin_id;
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(long admin_id, Employee employee)
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
        public ActionResult EditEmployee(long admin_id, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Employee employee = context.Employees.Find(id);
                if (employee != null)
                {
                    ViewBag.AdminId = admin_id;
                    return View("EditEmployee", employee);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult EditEmployee(long admin_id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    employee.UpdatedBy = admin_id;
                    employee.UpdatedDt = System.DateTime.Now;
                    Employee e = context.Employees.Find(employee.Id);
                    context.Entry(e).CurrentValues.SetValues(employee);
                    context.SaveChanges();
                }
                return View("EditEmployeeConfirmation", employee);
            }
            return View("Error");
        }

        public ActionResult UndoEditEmployee(long admin_id, Employee employee)
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
                return View("UndoEditEmployeeConfirmation", employee);
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult DeleteEmployee(long admin_id, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Employee employee = context.Employees.Find(id);
                if (employee != null && employee.Active != false)
                {
                    ViewBag.AdminId = admin_id;
                    ViewBag.Id = id;
                    employee.Active = false; // just set to not active
                    employee.UpdatedBy = admin_id;  
                    employee.UpdatedDt = System.DateTime.Now;
                    context.SaveChanges();
                    return View("DeleteEmployeeConfirmation", employee);
                }
                return View("Error");
            }
        }

        public ActionResult UndoDeleteEmployee(long admin_id, long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Employee employee = context.Employees.Find(id);
                if (employee != null && employee.Active != true)
                {
                    employee.Active = true; // just set to active
                    employee.UpdatedBy = admin_id;  
                    employee.UpdatedDt = System.DateTime.Now;
                    context.SaveChanges();
                    return View("UndoDeleteEmployeeConfirmation");
                }
            }
            return View("Error");
        }

        //todo...

        [HttpGet]
        public ActionResult VolunteerInformation(long admin_id, long id)
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