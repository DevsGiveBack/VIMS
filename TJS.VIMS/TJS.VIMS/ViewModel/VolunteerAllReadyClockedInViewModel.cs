using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TJS.VIMS.ViewModel
{
    public class VolunteerAllReadyClockedInViewModel : AuthorizedViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "User")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Organization")]
        [DataType(DataType.Text)]
        public string OrganizationName { get; set; }
    }
}