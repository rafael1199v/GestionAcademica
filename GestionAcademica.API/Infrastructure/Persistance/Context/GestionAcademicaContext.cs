using GestionAcademica.API.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using File = GestionAcademica.API.Infrastructure.Persistance.Models.File;

namespace GestionAcademica.API.Infrastructure.Persistance.Context;

public partial class GestionAcademicaContext : DbContext
{
    public GestionAcademicaContext()
    {
    }

    public GestionAcademicaContext(DbContextOptions<GestionAcademicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Models.Application> Applications { get; set; }

    public virtual DbSet<Career> Careers { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Hr> Hrs { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vacancy> Vacancies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__administ__3213E83F9FDE2434");

            entity.ToTable("administrators");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Administrators)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__administr__user___5C02A283");
        });

        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__applican__3213E83FF0CD7B57");

            entity.ToTable("applicants");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__applicant__user___61BB7BD9");
        });

        modelBuilder.Entity<Models.Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__applicat__3213E83FB55EBCCB");

            entity.ToTable("applications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.VacancyId).HasColumnName("vacancy_id");

            entity.HasOne(d => d.Applicant).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__applicati__appli__7993056A");

            entity.HasOne(d => d.Status).WithMany(p => p.Applications)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__applicati__statu__7A8729A3");

            entity.HasOne(d => d.Vacancy).WithMany(p => p.Applications)
                .HasForeignKey(d => d.VacancyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__applicati__vacan__789EE131");
        });

        modelBuilder.Entity<Career>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__careers__3213E83FCB67003E");

            entity.ToTable("careers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdministratorId).HasColumnName("administrator_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Administrator).WithMany(p => p.Careers)
                .HasForeignKey(d => d.AdministratorId)
                .HasConstraintName("FK__careers__adminis__6497E884");

            entity.HasMany(d => d.Subjects).WithMany(p => p.Careers)
                .UsingEntity<Dictionary<string, object>>(
                    "CareersSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__careers_s__subje__6B44E613"),
                    l => l.HasOne<Career>().WithMany()
                        .HasForeignKey("CareerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__careers_s__caree__6A50C1DA"),
                    j =>
                    {
                        j.HasKey("CareerId", "SubjectId").HasName("PK__careers___BE15FA6FCEA31F89");
                        j.ToTable("careers_subjects");
                        j.IndexerProperty<int>("CareerId").HasColumnName("career_id");
                        j.IndexerProperty<int>("SubjectId").HasColumnName("subject_id");
                    });
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__classroo__3213E83FB4F8A5CE");

            entity.ToTable("classrooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__files__3213E83FD6C913A8");

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
                    r => r.HasOne<Models.Application>().WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__applicati__appli__7E57BA87"),
                    l => l.HasOne<File>().WithMany()
                        .HasForeignKey("FileId")
                        .HasConstraintName("FK__applicati__file___7D63964E"),
                    j =>
                    {
                        j.HasKey("FileId", "ApplicationId").HasName("PK__applicat__346439099914EB0A");
                        j.ToTable("applications_files");
                        j.IndexerProperty<int>("FileId").HasColumnName("file_id");
                        j.IndexerProperty<int>("ApplicationId").HasColumnName("application_id");
                    });
        });

        modelBuilder.Entity<Hr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hr__3213E83F46D15308");

            entity.ToTable("hr");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Hrs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__hr__user_id__5EDF0F2E");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__professo__3213E83F6564C0FD");

            entity.ToTable("professors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Professors)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__professor__user___5649C92D");

            entity.HasMany(d => d.Files).WithMany(p => p.Professors)
                .UsingEntity<Dictionary<string, object>>(
                    "ProfessorsFile",
                    r => r.HasOne<File>().WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__professor__file___6F1576F7"),
                    l => l.HasOne<Professor>().WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__professor__profe__6E2152BE"),
                    j =>
                    {
                        j.HasKey("ProfessorId", "FileId").HasName("PK__professo__0DE121EDAD1CEBFC");
                        j.ToTable("professors_files");
                        j.IndexerProperty<int>("ProfessorId").HasColumnName("professor_id");
                        j.IndexerProperty<int>("FileId").HasColumnName("file_id");
                    });
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83FADFD5055");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__statuses__3213E83F24BD74F5");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3213E83F729EB1C1");

            entity.ToTable("students");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__students__user_i__592635D8");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subjects__3213E83F2C21C074");

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
                .HasConstraintName("FK__subjects__profes__6774552F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FC5877646");

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
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Habilitado")
                .HasColumnName("status");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__role_id__536D5C82");
        });

        modelBuilder.Entity<Vacancy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vacancie__3213E83FAD9DA766");

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
                .HasConstraintName("FK__vacancies__admin__75C27486");

            entity.HasOne(d => d.Career).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.CareerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__vacancies__caree__74CE504D");

            entity.HasOne(d => d.Subject).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__vacancies__subje__73DA2C14");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
