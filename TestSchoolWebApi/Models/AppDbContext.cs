using Microsoft.EntityFrameworkCore;

namespace TestSchool.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):
            base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
