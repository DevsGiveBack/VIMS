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
        [HttpGet]
        public ActionResult Start(long admin_id)
        {
            ViewBag.AdminId = admin_id;
            return View();
        }

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
                    int count = context.Organizations.
                        Where(m => m.OrganizationName == organization.OrganizationName).Count();
                    if (count == 0)
                    {
                        //BKP moved to view ?
                        //organization.Active = true;
                        //organization.CreatedBy = admin_id;
                        //organization.CreatedDt = System.DateTime.Now;
                        context.Organizations.Add(organization);
                        context.SaveChanges();
                        ViewBag.AdminId = admin_id;
                        return View("CreateOrganizationConfirmation", organization);
                    }
                 }
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
                    Organization organization_current = context.Organizations.Find(organization.Id);
                    Organization organization_saved = organization_current.ShallowCopy();
              
                    if (organization != null && (bool)organization.Active) // BKP fix should not be nullable
                    {
                        int count = context.Organizations.
                            Where(m => m.OrganizationName == organization.OrganizationName && m.Id != organization.Id).
                            Count();

                        if (count == 0)
                        {
                            organization.UpdatedBy = admin_id;
                            organization.UpdatedDt = System.DateTime.Now;
                            context.Entry(organization_current).CurrentValues.SetValues(organization);
                            context.SaveChanges();
                            return RedirectToAction("EditOrganizationConfirmation", organization_saved );
                        }
                    }
                }
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult EditOrganizationConfirmation(Organization organization)
        {
            return View("EditOrganizationConfirmation", organization);
        }

        [HttpPost]
        public ActionResult UndoEditOrganization(Organization organization)
        {
            if (ModelState.IsValid)
            {
                using (VIMSDBContext context = new VIMSDBContext())
                {
                    Organization current_organization = context.Organizations.Find(organization.Id);
                    if (organization != null && (bool)organization.Active) // BKP fix should not be nullable
                    {
                        int count = context.Organizations.
                            Where(m => m.OrganizationName == organization.OrganizationName && m.Id != organization.Id).
                            Count();

                        if (count == 0)
                        {
                            context.Entry(current_organization).CurrentValues.SetValues(organization);
                            context.SaveChanges();
                            return View("UndoEditOrganizationConfirmation");
                        }
                    }
                }
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
                    organization.Active = false;
                    organization.UpdatedBy = admin_id;
                    organization.UpdatedDt = DateTime.Now;
                    context.SaveChanges();

                    ViewBag.AdminId = admin_id;
                    ViewBag.Id = id;
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
                    int count = context.Employees.
                        Where(m => m.UserName == employee.UserName).Count();
                    if (count == 0)
                    {
                        employee.Active = true;
                        employee.CreatedBy = 0;
                        employee.CreatedDt = System.DateTime.Now;
                        context.Employees.Add(employee);
                        context.SaveChanges();
                        return View("CreateEmployeeConfirmation", employee);
                    }
                }
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
                    Employee current_employee = context.Employees.Find(employee.Id);
                    if (employee != null && (bool)employee.Active) // BKP fix should not be nullable
                    {
                        int count = context.Employees.
                            Where(m => m.UserName == employee.UserName && m.Id != employee.Id).
                            Count();

                        if (count == 0)
                        {
                            employee.UpdatedBy = admin_id;
                            employee.UpdatedDt = System.DateTime.Now;
                            context.Entry(current_employee).CurrentValues.SetValues(employee);
                            context.SaveChanges();
                            return View("EditemployeeConfirmation", employee);
                        }
                    }
                }
            }
            return View("Error");
        }

        //[HttpPost]
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

        [HttpGet]
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

        public ActionResult NoShows(VolunteerInfo volunteer)
        {
            // todo
            return View();
        }

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
        
        public ActionResult TestView()
        {
            // todo
            return View();
        }
    }
}