using Microsoft.EntityFrameworkCore;
using EduflowAdminBackend.Models;

namespace EduflowAdminBackend.Data
{
    public class AdminContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<AcademicPeriod> AcademicPeriods { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Section> Sections { get; set; }

        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
        }
    }
}