using Microsoft.EntityFrameworkCore;

namespace SzkolaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
