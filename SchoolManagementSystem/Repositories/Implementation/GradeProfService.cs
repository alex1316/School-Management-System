using SchoolManagementSystem.Models.Domain;
using SchoolManagementSystem.Repositories.Abstract;

namespace SchoolManagementSystem.Repositories.Implementation
{
    public class GradeProfService : IGradeService
    {
        private readonly DatabaseContext context;
        public GradeProfService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(GradeProf model)
        {
            try
            {
                context.Grades.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                context.Grades.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public GradeProf FindById(int id)
        {
            return context.Grades.Find(id);
        }

        public IEnumerable<GradeProf> GetAll()
        {
            var data = (from grades in context.Grades
                        join students in context.Students
                        on grades.StudentId equals students.Id
                        join subjects in context.Subjects on grades.SubjectId equals subjects.Id
                       
                        select new GradeProf
                        {
                            Id = grades.Id,
                            StudentId = grades.StudentId,
                            
                            GradesProf = grades.GradesProf,
                            SubjectId = grades.SubjectId,
                           ProfFrstname = grades.ProfFrstname,
                           ProfLastName = grades.ProfLastName,
                            
                           
                            StudentName = students.StudentName,
                            SubjectName = subjects.SubjectName,
                            StudentAM = students.StudentAM,
                            SubjectYear = subjects.SubjectYear,
                            SubjectSemester = subjects.SubjectSemester,

                        }
                        ).ToList();
            return data;
        }

        public IEnumerable<GradeProf> GetAll2()
        {
            var data = (from grades in context.Grades
                        join students in context.Students
                        on grades.StudentId equals students.Id
                        join subjects in context.Subjects on grades.SubjectId equals subjects.Id

                        select new GradeProf
                        {
                            Id = grades.Id,
                            StudentId = grades.StudentId,

                            GradesProf = grades.GradesProf,
                            SubjectId = grades.SubjectId,
                            ProfFrstname = grades.ProfFrstname,
                            ProfLastName = grades.ProfLastName,


                            StudentName = students.StudentName,
                            SubjectName = subjects.SubjectName,
                            StudentAM = students.StudentAM,
                            SubjectYear = subjects.SubjectYear,
                            SubjectSemester = subjects.SubjectSemester,

                        }
                        ).ToList();
            return data;
        }

        public bool Update(GradeProf model)
        {
            try
            {
                context.Grades.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
