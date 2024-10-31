using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task_14.Models;

public partial class ItiProjectContext : DbContext
{
    public ItiProjectContext()
    {
    }

    public ItiProjectContext(DbContextOptions<ItiProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Trainee> Trainees { get; set; }

    public virtual DbSet<TraineeCourse> TraineeCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-M284REV\\SQLEXPRESS;Database=iti_project;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasIndex(e => e.DeptId, "IX_Courses_DeptId");

            entity.Property(e => e.Name).HasDefaultValue("");

            entity.HasOne(d => d.Dept).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasIndex(e => e.CourseId, "IX_Instructors_CourseId");

            entity.HasIndex(e => e.Deptid, "IX_Instructors_Deptid");

            entity.Property(e => e.InstructorId).ValueGeneratedNever();
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Name).HasDefaultValue("");
            entity.Property(e => e.Salary).HasColumnName("salary");

            entity.HasOne(d => d.Course).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(d => d.Dept).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.Deptid)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.HasIndex(e => e.Deptid, "IX_Trainees_Deptid");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(40)
                .HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.Name).HasDefaultValue("");

            entity.HasOne(d => d.Dept).WithMany(p => p.Trainees)
                .HasForeignKey(d => d.Deptid)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<TraineeCourse>(entity =>
        {
            entity.HasKey(e => new { e.CourseId, e.TraineeId });

            entity.ToTable("Trainee_Courses");

            entity.HasIndex(e => e.TraineeId, "IX_Trainee_Courses_TraineeId");

            entity.Property(e => e.Degree).HasColumnName("degree");

            entity.HasOne(d => d.Course).WithMany(p => p.TraineeCourses).HasForeignKey(d => d.CourseId);

            entity.HasOne(d => d.Trainee).WithMany(p => p.TraineeCourses).HasForeignKey(d => d.TraineeId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
