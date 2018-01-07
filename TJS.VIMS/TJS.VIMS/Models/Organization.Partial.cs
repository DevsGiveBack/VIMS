using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TJS.VIMS
{
    public partial class Organization
    {
        //[Display(Name = "Test")]
        //public string Name { get; set; }

        public Organization Copy()
       {
            return (Organization)this.MemberwiseClone();
       }

        public Organization ShallowCopy()
        {
            Organization organization = new Organization();
            organization.Id = Id;
            organization.Name = Name;
            organization.Active = Active;
            organization.CreatedBy = CreatedBy;
            organization.CreatedDt = CreatedDt;
            organization.UpdatedBy = UpdatedBy;
            organization.UpdatedDt = UpdatedDt;
            return organization;
        }
    }
}