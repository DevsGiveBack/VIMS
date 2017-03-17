namespace TJS.VIMS.DAL2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VolunteerProfileInfo")]
    public partial class VolunteerProfileInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VolunteerProfileInfo()
        {
            VolunteerClockInOutInfoes = new HashSet<VolunteerClockInOutInfo>();
        }

        [Key]
        public long VolunteerProfileId { get; set; }

        public long? VolunteerId { get; set; }

        public int? OrganizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string CaseNumber { get; set; }

        public short? Volunteer_Hours_Needed { get; set; }

        [StringLength(50)]
        public string Skill { get; set; }

        [StringLength(400)]
        public string WorkInfo { get; set; }

        public bool Felony_Cnvctn { get; set; }

        public bool Sexual_Abuse_Related { get; set; }

        public bool Recv_Email { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDt { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolunteerClockInOutInfo> VolunteerClockInOutInfoes { get; set; }

        public virtual VolunteerInfo VolunteerInfo { get; set; }
    }
}
