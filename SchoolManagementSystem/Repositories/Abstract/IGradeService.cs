using SchoolManagementSystem.Models.Domain;

namespace SchoolManagementSystem.Repositories.Abstract
{
    public interface IGradeService
    {
        bool Add(GradeProf model);
        bool Update(GradeProf model);
        bool Delete(int id);
        GradeProf FindById(int id);
        IEnumerable<GradeProf> GetAll();
        IEnumerable<GradeProf> GetAll2();
    }
}
