using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TJS.VIMS.Models;

namespace TJS.VIMS.ViewModel
{
    public class AuthorizedViewModel
    {
        public AuthorizedViewModel()
        {
        }

        public AuthorizedViewModel(int locationId)
        {

        }

        //public AuthorizedViewModel(Employee employee, Location location)
        //{
        //    Employee = employee;
        //    Location = location;
        //}

        //public Employee Employee { get; set; }
        //public Location Location { get; set; }

        //[Required]
        [Display(Name = "AdminName")]
        public string AdminName { get; set; }

        //[Required]    
        //[StringLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[DataType(DataType.Text)]
        [Display(Name = "LocationId")]
        public int LocationId { get; set; }

        //[Required]
        [Display(Name = "Location")]
        public string LocationName { get; set; }
    }
}