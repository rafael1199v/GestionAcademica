using System;
using System.Collections.Generic;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Infrastructure.Persistence.Context;

public partial class GestionAcademicaContext(DbContextOptions<GestionAcademicaContext> options) : DbContext(options)
{
    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Infrastructure.Persistence.Models.Application> Applications { get; set; }

    public virtual DbSet<Career> Careers { get; set; }

    public virtual DbSet<Infrastructure.Persistence.Models.File> Files { get; set; }

    public virtual DbSet<Hr> Hrs { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vacancy> Vacancies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__administ__3213E83F7459D599");

            entity.ToTable("administrators");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Administrators)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__administr__user___39AD8A7F");
        });

        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__applican__3213E83FC5DBBC83");

            entity.ToTable("applicants");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__applicant__user___3F6663D5");
        });

        modelBuilder.Entity<Infrastructure.Persistence.Models.Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__applicat__3213E83FB42112DD");

            entity.ToTable("applications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.VacancyId).HasColumnName("vacancy_id");

            entity.HasOne(d => d.Applicant).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__applicati__appli__536D5C82");

            entity.HasOne(d => d.Status).WithMany(p => p.Applications)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__applicati__statu__546180BB");

            entity.HasOne(d => d.Vacancy).WithMany(p => p.Applications)
                .HasForeignKey(d => d.VacancyId)
                .HasConstraintName("FK__applicati__vacan__52793849");
        });

        modelBuilder.Entity<Career>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__careers__3213E83F44795343");

            entity.ToTable("careers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdministratorId).HasColumnName("administrator_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Administrator).WithMany(p => p.Careers)
                .HasForeignKey(d => d.AdministratorId)
                .HasConstraintName("FK__careers__adminis__4242D080");

            entity.HasMany(d => d.Subjects).WithMany(p => p.Careers)
                .UsingEntity<Dictionary<string, object>>(
                    "CareersSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__careers_s__subje__48EFCE0F"),
                    l => l.HasOne<Career>().WithMany()
                        .HasForeignKey("CareerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__careers_s__caree__47FBA9D6"),
                    j =>
                    {
                        j.HasKey("CareerId", "SubjectId").HasName("PK__careers___BE15FA6F2AA38869");
                        j.ToTable("careers_subjects");
                        j.IndexerProperty<int>("CareerId").HasColumnName("career_id");
                        j.IndexerProperty<int>("SubjectId").HasColumnName("subject_id");
                    });
        });

        modelBuilder.Entity<Infrastructure.Persistence.Models.File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__files__3213E83F09CA491F");

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

            entity.HasMany(d => d.Applications).WithMany(p => p.Files)
                .UsingEntity<Dictionary<string, object>>(
                    "ApplicationsFile",
                    r => r.HasOne<Infrastructure.Persistence.Models.Application>().WithMany()
                        .HasForeignKey("ApplicationId")
                        .HasConstraintName("FK__applicati__appli__5832119F"),
                    l => l.HasOne<Infrastructure.Persistence.Models.File>().WithMany()
                        .HasForeignKey("FileId")
                        .HasConstraintName("FK__applicati__file___573DED66"),
                    j =>
                    {
                        j.HasKey("FileId", "ApplicationId").HasName("PK__applicat__3464390929E801DC");
                        j.ToTable("applications_files");
                        j.IndexerProperty<int>("FileId").HasColumnName("file_id");
                        j.IndexerProperty<int>("ApplicationId").HasColumnName("application_id");
                    });
        });

        modelBuilder.Entity<Hr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hr__3213E83F34C18CC9");

            entity.ToTable("hr");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Hrs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__hr__user_id__3C89F72A");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__professo__3213E83FA186E171");

            entity.ToTable("professors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Professors)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__professor__user___36D11DD4");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F4F2CADED");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__statuses__3213E83FE83135A1");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subjects__3213E83FED62AB21");

            entity.ToTable("subjects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Initial)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("initial");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ProfessorId).HasColumnName("professor_id");

            entity.HasOne(d => d.Professor).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.ProfessorId)
                .HasConstraintName("FK__subjects__profes__451F3D2B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FC4E413A6");

            entity.ToTable("users");

            entity.HasIndex(e => e.InstitutionalEmail, "UQ__users__C2B05498C828CEF1").IsUnique();

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
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Habilitado")
                .HasColumnName("status");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__role_id__33F4B129");
        });

        modelBuilder.Entity<Vacancy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vacancie__3213E83F48A61147");

            entity.ToTable("vacancies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.CareerId).HasColumnName("career_id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Admin).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__vacancies__admin__4F9CCB9E");

            entity.HasOne(d => d.Career).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.CareerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__vacancies__caree__4EA8A765");

            entity.HasOne(d => d.Subject).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__vacancies__subje__4DB4832C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
