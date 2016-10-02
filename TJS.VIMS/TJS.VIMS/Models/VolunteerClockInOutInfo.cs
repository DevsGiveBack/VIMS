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

        public int? ClockInOutLocationId { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public string ClockInProfilePhotoPath { get; set; }

        public string ClockOutProfilePhotoPath { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Location Location { get; set; }

        public virtual VolunteerInfo VolunteerInfo { get; set; }

        public virtual VolunteerProfileInfo VolunteerProfileInfo { get; set; }
    }
}
