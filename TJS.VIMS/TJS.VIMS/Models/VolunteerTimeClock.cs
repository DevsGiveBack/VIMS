namespace TJS.VIMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VolunteerTimeClock")]
    public partial class VolunteerTimeClock
    {
        public long Id { get; set; }

        public long? LocationId { get; set; }

        public long? VolunteerId { get; set; }

        public long? VolunteerProfileId { get; set; }

        public DateTime? ClockIn { get; set; }

        public DateTime? ClockOut { get; set; }

        [StringLength(500)]
        public string ClockInPhoto { get; set; }

        [StringLength(500)]
        public string ClockOutPhoto { get; set; }

        public bool? Active { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDt { get; set; }

        public virtual Volunteer Volunteer { get; set; }

        public virtual VolunteerProfile VolunteerProfile { get; set; }
    }
}
