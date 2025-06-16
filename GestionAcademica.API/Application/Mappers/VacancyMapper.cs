using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Mappers;

public class VacancyMapper
{
    public static VacancyDTO MapVacancyModelToVacancyDto(Vacancy vacancy)
    {
        return new VacancyDTO
        {
            Id = vacancy.Id,
            Name = vacancy.Name,
            Description = vacancy.Description,
            StartTime = vacancy.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
            EndTime = vacancy.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
            CareerId = vacancy.CareerId,
            SubjectId = vacancy.SubjectId,
            AdminId = vacancy.AdminId,
            SubjectName = vacancy.Subject.Name,
            CareerName = vacancy.Career.Name,
            Closed = (vacancy.Applications.Any(application => application.Status.Id == (int)StatusEnum.ACCEPTED) || vacancy.EndTime <= DateTime.Now)
        };
    }
}