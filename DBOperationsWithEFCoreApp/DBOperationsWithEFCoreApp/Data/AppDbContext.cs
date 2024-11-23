using Microsoft.AspNetCore.Identity;
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
            modelBuilder.Entity<Students>().HasData
            (
                new Students() { Id = 9, FirstName = "Tarique", LastName = "Zaib", Email = "Tarique.Zaib@gmail.com" }                
            );
            modelBuilder.Entity<UserAccounts>().HasData(
                new UserAccounts()
                {
                    Id = 1,
                    FullName = "Tarique Zaib",
                    UserName = "TZaib",
                    Password = "admin123"
                });
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<UserAccounts> UserAccounts { get; set; }
    }
}
