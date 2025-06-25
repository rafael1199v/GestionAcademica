using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Infrastructure.Mappers;

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
            Closed = vacancy.Applications.Any(application => application.Status.Id == (int)StatusEnum.ACCEPTED) || vacancy.EndTime <= DateTime.Now
        };
    }
    public static UpdateVacancyDTO MapVacancyToUpdateVacancyDto(Vacancy vacancy)
    {
        return new UpdateVacancyDTO
        {
            Id = vacancy.Id,
            Name = vacancy.Name,
            Description = vacancy.Description,
            StartTime = vacancy.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
            EndTime = vacancy.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
            CareerId = vacancy.CareerId,
            SubjectId = vacancy.SubjectId
        };
    }
    public static Vacancy EntityToModel(VacancyEntity entity)
    {
        return new Vacancy
        {
            Name = entity.Name,
            Description = entity.Description,
            StartTime = entity.StartTime,
            EndTime = entity.EndTime,
            SubjectId = entity.SubjectId,
            CareerId = entity.CareerId,
            AdminId = entity.AdminId
        };
    }

    public static VacancyEntity ModelToVacancyEntity(Vacancy entity)
    {
        return new VacancyEntity
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            StartTime = entity.StartTime,
            EndTime = entity.EndTime,
            CareerId = entity.CareerId,
            SubjectId = entity.SubjectId,
            AdminId = entity.AdminId
        };
    }
    
}