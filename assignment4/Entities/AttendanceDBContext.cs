using assignment4.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace assignment4.Entities
{
    public class AttendanceDBContext : DbContext
    {
        public readonly string _connectionstring;
        public readonly string _migrationsAssembly;
        public AttendanceDBContext()
        {
            _connectionstring = @"Server=DESKTOP-TOQS6U4\SQLEXPRESS; Database=DbAttendance; User Id=AnikDB;Password=1234;";
            _migrationsAssembly = Assembly.GetExecutingAssembly().GetName().Name;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionstring, (x) => x.MigrationsAssembly(_migrationsAssembly));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ClassSchedule>().ToTable("ClassSchedules");
            modelBuilder.Entity<CourseRegestration>().ToTable("CourseRegestrations");
            modelBuilder.Entity<CourseRegestration>().HasKey((x) => new { x.CourseID, x.StudentID });

            modelBuilder.Entity<CourseAttendance>().ToTable("CourseAttendances");
            modelBuilder.Entity<CourseAttendance>().HasKey((x) => new { x.CourseID, x.StudentAttendanceID });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }

    }
}
