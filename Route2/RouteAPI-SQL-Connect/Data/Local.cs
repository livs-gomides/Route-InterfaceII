using System.ComponentModel.DataAnnotations;

namespace RouteAPI_SQL_Connect.Data
{
    public class Local
    {
        [Key]
        public Guid LocalID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}