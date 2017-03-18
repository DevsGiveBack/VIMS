namespace TJS.VIMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        public int LocationId { get; set; }

        [StringLength(100)]
        public string LocationName { get; set; }

        [StringLength(50)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string Address2 { get; set; }

        public short? StateId { get; set; }

        public short? CountryId { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(250)]
        public string Notes { get; set; }

        public bool? ActiveInd { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public virtual Country Country { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual State State { get; set; }
    }
}
