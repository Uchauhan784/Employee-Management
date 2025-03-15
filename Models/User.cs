using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required]
        public  required string Password { get; set; }
    }
}
