using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RouteAPI_SQL_Connect.Data
{
    public class Device
    {
        [Key]
        public Guid DeviceID { get; set; }

        [Required]
        public Guid PersonID { get; set; }

        [MaxLength(100)]
        public string DeviceName { get; set; }

        [MaxLength(50)]
        public string OperatingSystem { get; set; }

        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
    }
}