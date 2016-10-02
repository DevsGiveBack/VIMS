namespace TJS.VIMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VolunteerProfilePhotoInfo")]
    public partial class VolunteerProfilePhotoInfo
    {
        [Key]
        public long VolunteerProfilePhotoId { get; set; }

        public long? VolunteerId { get; set; }

        public string VolunteerProfilePhotoPath { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual VolunteerInfo VolunteerInfo { get; set; }
    }
}
