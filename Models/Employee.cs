using System.ComponentModel.DataAnnotations;

namespace Project_Ghiriti_Edmond.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        [Required]
        public int? DepartmentId { get; set; }
        [Required]
        [StringLength(25)]
        public string Position { get; set; }

        // Navigation property
        public Department Department { get; set; }
    }
}
