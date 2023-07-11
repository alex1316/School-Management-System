using SchoolManagementSystem.Models.Domain;
using SchoolManagementSystem.Repositories.Abstract;

namespace SchoolManagementSystem.Repositories.Implementation
{
    public class StudentAdminService : IStudentService
    {
        private readonly DatabaseContext context;
        public StudentAdminService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(StudentAdmin model)
        {
            try
            {
                context.Students.Add(model);
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
                context.Students.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public StudentAdmin FindById(int id)
        {
            return context.Students.Find(id);
        }

        public IEnumerable<StudentAdmin> GetAll()
        {
            return context.Students.ToList();
        }

        public bool Update(StudentAdmin model)
        {
            try
            {
                context.Students.Update(model);
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
