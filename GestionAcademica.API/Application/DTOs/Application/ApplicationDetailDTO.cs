using GestionAcademica.API.Application.DTOs.File;

namespace GestionAcademica.API.Application.DTOs.Application;

public class ApplicationDetailDTO
{
    public int Id { get; set; }
    public int VacancyId { get; set; }
    public int ApplicantId { get; set; }
    public int StatusId { get; set; }
    public string? VacancyName { get; set; }
    public string? VacancyDescription { get; set; }
    public string? VacancyCareerName { get; set; }
    public string? ApplicantName { get; set; }
    public string? AdministratorName { get; set; }
    
    public List<FileDTO> Files { get; set; }

    // TODO: Retornar el usuario solicitante
}