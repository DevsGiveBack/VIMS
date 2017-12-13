using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TJS.VIMS.DAL;
using TJS.VIMS.Models;


namespace TJS.VIMS.ViewModel
{
    public class VolunteerLookUpViewModel : AuthorizedViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [DataType(DataType.Text)]
        public string UserName { get; set;}

        public VolunteerLookUpViewModel() { }

        public VolunteerLookUpViewModel(Location location) : this((int)location.Id, location.LocationName)
        {
        }

        public VolunteerLookUpViewModel(int locationId, string locationName)
        {
            this.LocationId = locationId;
            this.LocationName = locationName;
        }
    }
}