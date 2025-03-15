namespace EmployeeManagement.DTOs
{
    public class EmployeeDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Position { get; set; }
        public decimal Salary { get; set; }
    }
}
