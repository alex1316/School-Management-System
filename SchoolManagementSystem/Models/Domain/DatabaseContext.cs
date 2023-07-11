using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<StudentAdmin> Students { get; set; }
        public DbSet<SubjectAdmin> Subjects { get; set; }
        public DbSet<GradeProf> Grades { get; set; }
        public DbSet<GradeUser> GradesUser { get; set; }

    }
}
