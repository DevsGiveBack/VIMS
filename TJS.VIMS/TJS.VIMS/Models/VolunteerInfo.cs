namespace TJS.VIMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VolunteerInfo")]
    public partial class VolunteerInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VolunteerInfo()
        {
            VolunteerClockInOutInfoes = new HashSet<VolunteerClockInOutInfo>();
            VolunteerProfileInfoes = new HashSet<VolunteerProfileInfo>();
            VolunteerProfilePhotoInfoes = new HashSet<VolunteerProfilePhotoInfo>();
        }

        [Key]
        public long VolunteerId { get; set; }

        public int? DefaultVolunteerProfileInfoId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public short? StateId { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        public short? PhoneNumberType { get; set; }

        [StringLength(75)]
        public string Email { get; set; }

        public DateTime? DOB { get; set; }

        [Display(Name = "Emergency Contact")]
        [StringLength(100)]
        public string Emrgncy_Cntct_Name { get; set; }

        [Display(Name = "Emergency Contact Phone")]
        [StringLength(12)]
        public string Emrgncy_Cntct_Phn { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDt { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDt { get; set; }

        public virtual State State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolunteerClockInOutInfo> VolunteerClockInOutInfoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolunteerProfileInfo> VolunteerProfileInfoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolunteerProfilePhotoInfo> VolunteerProfilePhotoInfoes { get; set; }
    }
}
