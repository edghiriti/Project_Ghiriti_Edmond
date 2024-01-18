using System.ComponentModel.DataAnnotations;

namespace Project_Ghiriti_Edmond.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(25)]
        public string Role { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime AssignmentDate { get; set; }

        // Navigation properties
        public Project Project { get; set; }
        public Employee Employee { get; set; }
    }

}
