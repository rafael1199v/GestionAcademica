namespace GestionAcademica.API.Domain.Entities;

public class SubjectEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Initial { get; set; }

    public string Description { get; set; } = null!;

    public int Credits { get; set; }

    public int? ProfessorId { get; set; }
}