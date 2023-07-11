using SchoolManagementSystem.Models.Domain;
using SchoolManagementSystem.Repositories.Abstract;

namespace SchoolManagementSystem.Repositories.Implementation
{
    public class SubjectAdminService : ISubjectService
    {
        private readonly DatabaseContext context;
        public SubjectAdminService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(SubjectAdmin model)
        {
            try
            {
                context.Subjects.Add(model);
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
                context.Subjects.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public SubjectAdmin FindById(int id)
        {
            return context.Subjects.Find(id);
        }

        public IEnumerable<SubjectAdmin> GetAll()
        {
            return context.Subjects.ToList();
        }

        public bool Update(SubjectAdmin model)
        {
            try
            {
                context.Subjects.Update(model);
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
