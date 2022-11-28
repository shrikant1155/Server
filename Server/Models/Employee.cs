using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int DepartmentID { get; set; }
    }
}
