 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJS.VIMS.Models;

namespace TJS.VIMS.DAL
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(VIMSDBContext context) : base(context)
        {
        }

        public Organization Create(long admin_id, string name)
        {
            Organization organization = new Organization();
            organization.Active = true;
            organization.CreatedBy = admin_id;
            organization.CreatedDt = DateTime.Now;

            // assert name does not exist
            int count = context.Organizations.
                        Where(m => m.Name == name).Count();
            if (count == 0)
            {
                context.Organizations.Add(organization);
                context.SaveChanges();
                return organization;
            }
            return null;
        }

        public bool Create(Organization organization)
        {
            // assert name does not exist
            int count = context.Organizations.
                        Where(m => m.Name == organization.Name).Count();
            if (count == 0)
            {
                Add(organization);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}