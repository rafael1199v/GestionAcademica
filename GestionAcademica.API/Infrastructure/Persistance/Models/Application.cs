namespace GestionAcademica.API.Infrastructure.Persistance.Models;

public partial class Application
{
    public int Id { get; set; }

    public int VacancyId { get; set; }

    public int ApplicantId { get; set; }

    public int StatusId { get; set; }

    public virtual Applicant Applicant { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual Vacancy Vacancy { get; set; } = null!;

    public virtual ICollection<File> Files { get; set; } = new List<File>();
}
