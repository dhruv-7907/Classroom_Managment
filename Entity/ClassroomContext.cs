using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Classroom_Managment.Entity;

public partial class ClassroomContext : DbContext
{
    public ClassroomContext()
    {
    }

    public ClassroomContext(DbContextOptions<ClassroomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentWork> StudentWorks { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Work> Works { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.ToTable("Classroom");

            entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");
            entity.Property(e => e.ClassroomName).HasMaxLength(100);
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Classroom_Teacher");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.StudentName).HasMaxLength(100);
        });

        modelBuilder.Entity<StudentWork>(entity =>
        {
            entity.ToTable("StudentWork");

            entity.Property(e => e.StudentWorkId).HasColumnName("StudentWorkID");
            entity.Property(e => e.CompletionStatus).HasMaxLength(50);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.WorkId).HasColumnName("WorkID");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentWorks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentWork_Work");

            entity.HasOne(d => d.Work).WithMany(p => p.StudentWorks)
                .HasForeignKey(d => d.WorkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Work_StudentWork");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.TeacherName).HasMaxLength(100);
        });

        modelBuilder.Entity<Work>(entity =>
        {
            entity.ToTable("Work");

            entity.Property(e => e.WorkId).HasColumnName("WorkID");
            entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.WorkDescription).HasMaxLength(500);
            entity.Property(e => e.WorkTitle).HasMaxLength(100);

            entity.HasOne(d => d.Classroom).WithMany(p => p.Works)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Work_classroom");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Works)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Work_Teacher");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
