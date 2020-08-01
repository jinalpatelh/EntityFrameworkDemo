using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            

        }

        public class SchoolContext : DbContext
        {

            public DbSet<StudentPoco> Students { get; set; }
            public DbSet<CoursePoco> Courses { get; set; }
            public DbSet<TeacherPoco> Teachers { get; set; }
            public DbSet<MarkPoco> Marks { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-DTULATU7\HUMBERBRIDGING;Initial Catalog=HUMBER_MARKS_DB;Integrated Security=True;");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<MarkPoco>()
                    .HasKey(e => new { e.CourseId, e.StudentId });
                
                modelBuilder.Entity<StudentCoursePoco>()
                    .HasKey(e => new { e.CourseId, e.StudentId });

                base.OnModelCreating(modelBuilder);
            }
        }
        public class StudentPoco
        {
            public int Id { get; set; }
            
            [MaxLength(50)]
            public string Name { get; set; }
            public int CourseId { get; set; }
            public List<StudentCoursePoco> StudentCourse { get; set; }
            
        }
        public class CoursePoco
        {
            public int Id { get; set; }
            
            [MaxLength(50)]
            public string Name { get; set; }
            public TeacherPoco Teacher { get; set; }
            public List<StudentCoursePoco> StudentCourse { get; set; }

        }
        public class TeacherPoco
        {
            [Key]
            public int Id { get; set; }
            [MaxLength(50)]
            public string Name { get; set; }
            public int CourseId { get; set; }
            public List<CoursePoco> Course { get; set; }
        }
        public class MarkPoco
        {
            public int CourseId { get; set; }
            public int StudentId { get; set; }
            public double Mark { get; set; }
            public double MaxMark { get; set; }
            public CoursePoco Course { get; set; }
            public StudentPoco Student { get; set; }
        }

        public class StudentCoursePoco
        {
            public int StudentId { get; set; }
            public int CourseId { get; set; }
            public StudentPoco Student { get; set; }
            public CoursePoco Course { get; set; }
        }

    }
}
