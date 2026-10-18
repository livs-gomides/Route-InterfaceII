using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RouteAPI_SQL_Connect.Data
{
    public class PositioningLog
    {
        [Key]
        public Guid LogID { get; set; }

        [Required]
        public Guid PersonID { get; set; }

        [Required]
        public Guid BeaconID { get; set; }

        [Column(TypeName = "decimal(10,4)")]
        public decimal? CalculatedX { get; set; }

        [Column(TypeName = "decimal(10,4)")]
        public decimal? CalculatedY { get; set; }

        [Required]
        public DateTime CapturedAt { get; set; }

        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }

        [ForeignKey("BeaconID")]
        public virtual BeaconInfo BeaconInfo { get; set; }
    }
}