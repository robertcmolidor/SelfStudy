using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisplayProbeResults.EntityModels
{
    [Table("es_probe.Result")]
    public partial class Result
    {
        public Guid ResultID { get; set; }

        [Key]
        [Column(Order = 0)]
        public Guid ProfileID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime HourStamp { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "datetime2")]
        public DateTime TimeStamp { get; set; }

        public int Latency { get; set; }

        [Required]
        [StringLength(100)]
        public string LocationDescription { get; set; }

        public bool Success { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual Profile Profile1 { get; set; }

        public virtual Profile Profile2 { get; set; }
    }
}
