using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJS.VIMS.Models;

namespace TJS.VIMS.DAL
{
    public class AdministrationRepository
    {
        public bool CreateEmployee(Employee employee)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                int count = context.Employees.
                    Where(m => m.UserName == employee.UserName).Count();
                if (count == 0)
                {
                    employee.Active = true;
                    employee.CreatedDt = DateTime.Now;
                    employee.UpdatedBy = null; // reset to null if not already
                    employee.UpdatedDt = null; // reset to null if not already
                    context.Employees.Add(employee);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool CreateOrganization(Organization organization)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                int count = context.Organizations.
                    Where(m => m.OrganizationName == organization.OrganizationName).Count();
                if (count == 0)
                {
                    organization.Active = true;
                    organization.CreatedDt = DateTime.Now;
                    organization.UpdatedBy = null; // reset to null if not already
                    organization.UpdatedDt = null; // reset to null if not already
                    context.Organizations.Add(organization);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteEmployee(long id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrganization(long id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Organization organization = context.Organizations.Find(id);
                if (organization != null && (bool)organization.Active)
                {
                    organization.Active = false;
                    organization.UpdatedDt = DateTime.Now;
                    context.SaveChanges();

                    return true;
                }
                return false;
            }
        }

        public bool EditEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool EditOrganization(Organization organization)
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
                        //organization.UpdatedBy = admin_id; // todo
                        organization.UpdatedDt = System.DateTime.Now;
                        context.Entry(organization_current).CurrentValues.SetValues(organization);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        public bool UnDeleteEmployee(long admin_id, long employee_id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Employee employee = context.Employees.Find(employee_id);
                if (employee != null && employee.Active != true)
                {
                    employee.Active = true; // just set to active
                    employee.UpdatedBy = admin_id;
                    employee.UpdatedDt = System.DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool UnDeleteOrganization(long admin_id, long organization_id)
        {
            using (VIMSDBContext context = new VIMSDBContext())
            {
                Organization organization = context.Organizations.Find(organization_id);
                if (organization != null && organization.Active != true)
                {
                    organization.Active = true; // just set to active
                    organization.UpdatedBy = admin_id;
                    organization.UpdatedDt = System.DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        //public bool UnDeleteEnitiy<T>(long admin_id, long enitity_id)
        //{
        //    using (VIMSDBContext context = new VIMSDBContext())
        //    {
        //        DbSet enitities = context.Set<T>();
        //        if (organization != null && organization.Active != true)
        //        { 
        //            context.SaveChanges();
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}