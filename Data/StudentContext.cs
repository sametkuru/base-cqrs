using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace Udemy.Cqrs.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Name = "SAmet",
                    Surname = "Kuru",
                    Age = 30,
                    Id = 1
                },
                new Student()
                {
                    Name = "Mehmet",
                    Surname = "Veli",
                    Age = 2,
                    Id = 2
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}