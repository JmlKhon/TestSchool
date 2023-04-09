using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace TestSchool.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) :
             base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
