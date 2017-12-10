using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TJS.VIMS.Models
{
    public class MyTable2
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OrganizationName { get; set; }
    }
}