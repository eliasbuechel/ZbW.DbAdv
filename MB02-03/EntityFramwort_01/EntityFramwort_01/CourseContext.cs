using EFCoreDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo
{
    public class CourseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTag>()
                .HasKey(t => new { t.CourseId, t.TagId });

            // Beziehungen angeben (hauptsächlich bei m:n verknüpfungen)
            modelBuilder.Entity<CourseTag>()
                .HasOne(pt => pt.Course)            // hat ein Tag
                .WithMany(t => t.CourseTags)        // welches auf Tag.CourseTags verweist
                .HasForeignKey(ct => ct.CourseId);

            modelBuilder.Entity<CourseTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.CourseTags)
                .HasForeignKey(ct => ct.TagId);

            // Data Seeding
            modelBuilder.Entity<Author>().HasData(new Author { Id = 10, Name = "Max", Salary = 29328.23m });
            modelBuilder.Entity<Author>().HasData(new Author { Id = 20, Name = "Fritzli", Salary = 216.23m });
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-9L41U7GC\\SQLSERVER_EB;Database=EFCoreDemo;Trusted_Connection=True;MultipleActiveResultSets=True;");
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);

            optionsBuilder.UseLazyLoadingProxies();

            
        }
    }
}
