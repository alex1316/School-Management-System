using SchoolManagementSystem.Models.Domain;

namespace SchoolManagementSystem.Repositories.Abstract
{
    public interface IGradeUserService
    {
        bool Add(GradeUser model);
        bool Update(GradeUser model);
        bool Delete(int id);
        GradeUser FindById(int id);
        IEnumerable<GradeUser> GetAll();
    }
}
