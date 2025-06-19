using GestionAcademica.API.Domain.Enums;

namespace GestionAcademica.API.Application.DTOs.Application;

public class CreateApplicationDTO
{
    public int VacancyId { get; set; }
    public int ApplicantId { get; set; }
    public int StatusId { get; set; } = (int)StatusEnum.UNDER_REVIEW;
    public List<IFormFile>? Files { get; set; }
}