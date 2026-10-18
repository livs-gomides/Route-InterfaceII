using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RouteAPI_SQL_Connect.Data
{
    public class SubLocal
    {
        [Key]
        public Guid SubLocalID { get; set; }

        [Required]
        public Guid LocalID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int FloorLevel { get; set; }

        [ForeignKey("LocalID")]
        public virtual Local Local { get; set; }
    }
}