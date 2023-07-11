using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models.Domain
{
    public class SubjectAdmin
    {
        public int Id { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string SubjectYear { get; set; }
        [Required]
        public string SubjectSemester{ get; set; }
    }
}
