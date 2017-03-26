namespace TJS.VIMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VolunteerClockInOutInfo")]
    public partial class VolunteerClockInOutInfo
    {
        [Key]
        public long VolunteerClockInOutId { get; set; }

        public long? VolunteerId { get; set; }

        public long? VolunteerProfileId { get; set; }

        public DateTime? ClockInDateTime { get; set; }

        public DateTime? ClockOutDateTime { get; set; }

        [StringLength(500)]
        public string ClockInProfilePhotoPath { get; set; }

        [StringLength(500)]
        public string ClockOutProfilePhotoPath { get; set; }

        public int? ClockInOutLocationId { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public virtual VolunteerProfileInfo VolunteerProfileInfo { get; set; }

        public virtual VolunteerInfo VolunteerInfo { get; set; }
    }
}
