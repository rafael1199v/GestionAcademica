namespace GestionAcademica.API.Application.DTOs.Vacancy;

public class VacancyDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string StartTime { get; set; }

    public string EndTime { get; set; }

    public int SubjectId { get; set; }

    public int CareerId { get; set; }

    public int AdminId { get; set; }

    public string CareerName { get; set; } = null!;
    
    public string SubjectName { get; set; } = null!;
    
    public bool Closed { get; set; }
    
}