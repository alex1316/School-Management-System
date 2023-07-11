using SchoolManagementSystem.Models.Domain;

namespace SchoolManagementSystem.Repositories.Abstract
{
    public interface IStudentService
    {
        bool Add(StudentAdmin model);
        bool Update(StudentAdmin model);
        bool Delete(int id);
        StudentAdmin FindById(int id);
        IEnumerable<StudentAdmin> GetAll();
    }
}
