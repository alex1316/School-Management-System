using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models.Domain
{
    public class GradeProf
    {
        public int Id { get; set; }
        [Required]
        public string ProfFrstname { get; set; }

        [Required]
        public string ProfLastName { get; set; }
        [Required]
        public string GradesProf { get; set; }

        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        

        [NotMapped]
        public string? StudentName { get; set; }
        [NotMapped]
        public string? SubjectName { get; set; }
        [NotMapped]
        public string? StudentAM { get; set; }
        [NotMapped]
        public string? SubjectYear { get; set; }
        [NotMapped]
        public string? SubjectSemester { get; set; }



        [NotMapped]
        public List<SelectListItem>? StudentList { get; set; }
        [NotMapped]
        public List<SelectListItem>? SubjectList { get; set; }
        
    }
}
