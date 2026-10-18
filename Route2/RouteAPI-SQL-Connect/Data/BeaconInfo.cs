using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RouteAPI_SQL_Connect.Data
{
    public class BeaconInfo
    {
        [Key]
        public Guid BeaconID { get; set; }

        [Required]
        public Guid SubLocalID { get; set; }

        [Required]
        [MaxLength(17)]
        public string MacAddress { get; set; }

        [Required]
        [MaxLength(36)]
        public string UuidString { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,4)")]
        public decimal CoordinateX { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,4)")]
        public decimal CoordinateY { get; set; }

        public int? BatteryLevel { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [ForeignKey("SubLocalID")]
        public virtual SubLocal SubLocal { get; set; }
    }
}