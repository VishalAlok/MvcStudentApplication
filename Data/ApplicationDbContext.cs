using Microsoft.EntityFrameworkCore;
using MvsStudentApplication.Models.Entities;

namespace MvsStudentApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
