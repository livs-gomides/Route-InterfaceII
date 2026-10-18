using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RouteAPI_SQL_Connect.Data
{
    public class PointOfInterest
    {
        [Key]
        public Guid PoiID { get; set; }

        [Required]
        public Guid SubLocalID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,4)")]
        public decimal CoordinateX { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,4)")]
        public decimal CoordinateY { get; set; }

        [ForeignKey("SubLocalID")]
        public virtual SubLocal SubLocal { get; set; }
    }
}