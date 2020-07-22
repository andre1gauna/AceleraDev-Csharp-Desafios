using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEF
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CursoAluno> CursoAlunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=INSPIRON\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(p => p.BirthDate)
                  .HasColumnType("Date")
                    .IsRequired();

            modelBuilder.Entity<Course>();

            modelBuilder.Entity<CursoAluno>().HasKey(x => new { x.CourseId, x.StudentId});

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
    

