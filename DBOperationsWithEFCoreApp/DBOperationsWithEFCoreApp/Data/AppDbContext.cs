using Microsoft.EntityFrameworkCore;

namespace DBOperationsWithEFCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData
            (
                new Student() { Id = 1, FirstName = "Tarique", LastName = "Zaib", Email = "Tarique.Zaib@gmail.com" }
            );
        }

        public DbSet<Student> Student { get; set; }
    }
}
