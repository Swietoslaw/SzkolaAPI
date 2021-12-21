using Microsoft.EntityFrameworkCore;

namespace SzkolaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<ClassTeacher> ClassTeacher { get; set; }
    }
}
