namespace TJS.VIMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VolunteerPhoto")]
    public partial class VolunteerPhoto
    {
        public long Id { get; set; }

        public long? VolunteerId { get; set; }

        [StringLength(500)]
        public string Path { get; set; }

        public bool? Active { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDt { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Volunteer Volunteer { get; set; }
    }
}
