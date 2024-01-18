using System.ComponentModel.DataAnnotations;

namespace Project_Ghiriti_Edmond.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        [Required]
        [StringLength(55)]
        public string Location { get; set; }

        // Navigation property
        public ICollection<Employee> Employees { get; set; }
    }

}
