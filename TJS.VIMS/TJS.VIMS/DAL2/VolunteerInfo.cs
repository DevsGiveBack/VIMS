namespace TJS.VIMS.DAL2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VolunteerInfo")]
    public partial class VolunteerInfo
    {
        public long Id { get; set; }

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

        public short? CountryId { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        public short? PhoneNumberType { get; set; }

        [StringLength(75)]
        public string Email { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(100)]
        public string Emrgncy_Cntct_Name { get; set; }

        [StringLength(12)]
        public string Emrgncy_Cntct_Phn { get; set; }

        public bool? Active { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDt { get; set; }
    }
}
