using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisplayProbeResults.EntityModels
{
    [Table("es_probe.Profile")]
    public partial class Profile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profile()
        {
            Results = new HashSet<Result>();
            Results1 = new HashSet<Result>();
            Results2 = new HashSet<Result>();
        }

        public Guid ProfileID { get; set; }

        public int CompanyID { get; set; }

        public int CustomerID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int CheckType { get; set; }

        public int CheckInterval { get; set; }

        [Required]
        public string Parameters { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public DateTimeOffset LastTimeChecked { get; set; }

        public bool Enabled { get; set; }

        public int DurationInterval { get; set; }

        public int? AlertProfileID { get; set; }

        public bool SendResolved { get; set; }

        public int NotificationInterval { get; set; }

        public Guid? MachineID { get; set; }

        public Guid? PreferredLocationID { get; set; }

        public int MaximumNotifications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results2 { get; set; }
    }
}
