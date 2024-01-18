using System.ComponentModel.DataAnnotations;

namespace Project_Ghiriti_Edmond.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        [StringLength(40)]
        public string ProjectName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        // Navigation property
        public ICollection<Assignment> Assignments { get; set; }
    }

}
