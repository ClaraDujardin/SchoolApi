using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Class> Classes => Set<Class>();
    public DbSet<Student> Students => Set<Student>();

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Class)
            .WithMany(c => c.Students) // la classe à plusieurs étudiants
            .HasForeignKey(s => s.ClassId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete if class is deleted

       
    }
}

