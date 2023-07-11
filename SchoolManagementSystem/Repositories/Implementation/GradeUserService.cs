using SchoolManagementSystem.Models.Domain;
using SchoolManagementSystem.Repositories.Abstract;

namespace SchoolManagementSystem.Repositories.Implementation
{
    public class GradeUserService : IGradeUserService
    {
        private readonly DatabaseContext context;
        public GradeUserService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(GradeUser model)
        {
            try
            {
                context.GradesUser.Add(model);
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
                context.GradesUser.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public GradeUser FindById(int id)
        {
            return context.GradesUser.Find(id);
        }

        public IEnumerable<GradeUser> GetAll()
        {
            var data = (from gradesuser in context.GradesUser
                        join students in context.Students
                        on gradesuser.StudentId equals students.Id
                        join subjects in context.Subjects on gradesuser.SubjectId equals subjects.Id
                        join grades in context.Grades on gradesuser.GradesId equals grades.Id

                        select new GradeUser
                        {
                            Id = gradesuser.Id,
                            StudentId = gradesuser.StudentId,
                            SubjectId = gradesuser.SubjectId,
                            GradesId = gradesuser.GradesId,

                            GradesProf = grades.GradesProf,
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

        public bool Update(GradeUser model)
        {
            try
            {
                context.GradesUser.Update(model);
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
