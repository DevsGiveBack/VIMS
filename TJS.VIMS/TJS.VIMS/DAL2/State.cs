namespace TJS.VIMS.DAL2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("State")]
    public partial class State
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public State()
        {
            Locations = new HashSet<Location>();
            VolunteerInfoes = new HashSet<VolunteerInfo>();
        }

        public short StateId { get; set; }

        [StringLength(100)]
        public string StateName { get; set; }

        public short? CountryId { get; set; }

        public bool? ActiveInd { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public virtual Country Country { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Location> Locations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolunteerInfo> VolunteerInfoes { get; set; }
    }
}
