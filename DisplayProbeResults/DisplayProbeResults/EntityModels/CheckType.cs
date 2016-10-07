namespace DisplayProbeResults.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("es_probe.CheckType")]
    public partial class CheckType
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CheckTypeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
