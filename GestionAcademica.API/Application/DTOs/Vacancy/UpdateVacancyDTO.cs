namespace GestionAcademica.API.Application.DTOs.Vacancy;

public class UpdateVacancyDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public int SubjectId { get; set; }
    public int CareerId { get; set; }
}