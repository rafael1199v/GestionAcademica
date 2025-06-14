namespace GestionAcademica.API.Infrastructure.Persistance.Models;

public partial class Vacancy
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int SubjectId { get; set; }

    public int CareerId { get; set; }

    public int AdminId { get; set; }

    public virtual Administrator Admin { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Career Career { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
