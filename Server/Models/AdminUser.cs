using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class AdminUser
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Mobile { get; set; }
    }
}
