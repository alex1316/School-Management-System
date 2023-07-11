using SchoolManagementSystem.Models.Domain;

namespace SchoolManagementSystem.Repositories.Abstract
{
    public interface ISubjectService
    {
        bool Add(SubjectAdmin model);
        bool Update(SubjectAdmin model);
        bool Delete(int id);
        SubjectAdmin FindById(int id);
        IEnumerable<SubjectAdmin> GetAll();
    }
}
