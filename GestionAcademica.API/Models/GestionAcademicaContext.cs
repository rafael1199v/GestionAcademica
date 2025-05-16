using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Models;

public partial class GestionAcademicaContext : DbContext
{
    public GestionAcademicaContext()
    {
    }

    public GestionAcademicaContext(DbContextOptions<GestionAcademicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Parallel> Parallels { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<ProfessorsFile> ProfessorsFiles { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__classes__3213E83FDEFA1A76");

            entity.ToTable("classes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.ParallelId).HasColumnName("parallel_id");
            entity.Property(e => e.ProfessorId).HasColumnName("professor_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Classes)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__classes__classro__5F7E2DAC");

            entity.HasOne(d => d.Parallel).WithMany(p => p.Classes)
                .HasForeignKey(d => d.ParallelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__classes__paralle__5E8A0973");

            entity.HasOne(d => d.Professor).WithMany(p => p.Classes)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__classes__profess__5D95E53A");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__classroo__3213E83F7F1081E0");

            entity.ToTable("classrooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__files__3213E83F7A5134D2");

            entity.ToTable("files");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FileDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("file_description");
            entity.Property(e => e.FileExtension)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("file_extension");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_path");
            entity.Property(e => e.Filename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("filename");
        });

        modelBuilder.Entity<Parallel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__parallel__3213E83FD1B0A7E4");

            entity.ToTable("parallels");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ParallelNumber).HasColumnName("parallel_number");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Subject).WithMany(p => p.Parallels)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__parallels__subje__55F4C372");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__professo__3213E83FF9E8AB11");

            entity.ToTable("professors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Professors)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__professor__user___503BEA1C");
        });

        modelBuilder.Entity<ProfessorsFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__professo__3213E83F9481F7AC");

            entity.ToTable("professors_files");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FileId).HasColumnName("file_id");
            entity.Property(e => e.ProfessorId).HasColumnName("professor_id");

            entity.HasOne(d => d.File).WithMany(p => p.ProfessorsFiles)
                .HasForeignKey(d => d.FileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__professor__file___59C55456");

            entity.HasOne(d => d.Professor).WithMany(p => p.ProfessorsFiles)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__professor__profe__58D1301D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F19A39F55");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3213E83FBB424402");

            entity.ToTable("students");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__students__user_i__531856C7");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subjects__3213E83FD45A66BE");

            entity.ToTable("subjects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.Initial)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("initial");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FA33841F3");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.InstitutionalEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("institutional_email");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PersonalEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("personal_email");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__role_id__4D5F7D71");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
