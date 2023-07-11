using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models.Domain
{
    public class StudentAdmin
    {
        public int Id { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentAM { get; set; }
       
    }
}
