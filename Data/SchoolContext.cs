using Microsoft.EntityFrameworkCore;
using NetbcCosmos.Models;

namespace NetbcCosmos.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                "YOUR-COSMOSDB-ENPOINT",
                "YOUR-KEY",
                "SchoolDB"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().OwnsOne(j => j.Room);
            modelBuilder.HasDefaultContainer("Courses");
            modelBuilder.Entity<Course>().OwnsMany(j => j.Students);
        }
    }

}