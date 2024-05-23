using Course.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Course.Infrastructure.Contexts
{
    public class CourseDbContext(DbContextOptions<CourseDbContext> options) : DbContext(options)
    {
        public DbSet<CourseEntity> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseEntity>().ToContainer("Courses");
            modelBuilder.Entity<CourseEntity>().HasPartitionKey(c => c.Id);
            modelBuilder.Entity<CourseEntity>().OwnsOne(c => c.Prices);
            modelBuilder.Entity<CourseEntity>().OwnsMany(c => c.Authors);
            modelBuilder.Entity<CourseEntity>().OwnsMany(c => c.ProgramDetails);

        }
    }
}
