namespace GestionAcademica.API.Domain.Entities;

public class VacancyEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int SubjectId { get; set; }

    public int CareerId { get; set; }

    public int AdminId { get; set; }
}