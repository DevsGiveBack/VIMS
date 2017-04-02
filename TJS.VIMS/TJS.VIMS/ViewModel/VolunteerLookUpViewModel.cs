using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TJS.VIMS.DAL;
using TJS.VIMS.Models;


namespace TJS.VIMS.ViewModel
{
    public class VolunteerLookUpViewModel
    {
        public string LocationName { get; set; }
        public int LocationId { get; set; }
         
        [Required]
        [Display(Name = "Username")]
        [DataType(DataType.Text)]
        public string UserName { get; set;}

        public VolunteerLookUpViewModel() { }

        public VolunteerLookUpViewModel(string locId, string locationName)
        {
            if (locId != null)
            {
                this.LocationId = Convert.ToInt32(locId);
            }
            this.LocationName = locationName;
        }
    }
}