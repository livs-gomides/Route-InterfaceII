using System.ComponentModel.DataAnnotations;

namespace RouteAPI_SQL_Connect.Data
{
    public class Person
    {
        [Key]
        public Guid PersonID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}