namespace TJS.VIMS.DAL2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VolunteerClockInOutInfo")]
    public partial class VolunteerClockInOutInfo
    {
        public long Id { get; set; }

        public long? VolunteerId { get; set; }

        public long? VolunteerProfileId { get; set; }

        public int? LocationId { get; set; }

        public DateTime? ClockInDateTime { get; set; }

        public DateTime? ClockOutDateTime { get; set; }

        [StringLength(500)]
        public string ClockInProfilePhotoPath { get; set; }

        [StringLength(500)]
        public string ClockOutProfilePhotoPath { get; set; }

        public int? ClockInOutLocationId { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDt { get; set; }
    }
}
