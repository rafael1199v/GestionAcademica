using GestionAcademica.API.Application.DTOs.Career;
using GestionAcademica.API.Application.DTOs.Subject;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Infrastructure.Mappers;

public class SubjectMapper
{
    public static SubjectWithCareersDTO MapToSubjectWithCareersDTO(Subject subject)
    {
        return new SubjectWithCareersDTO
        {
            Id = subject.Id,
            Name = subject.Name,
            Description = subject.Description,
            Credits = subject.Credits,
            Careers = subject.Careers.Select(career => new CareerDTO
            {
                Id = career.Id,
                Name = career.Name,
                AdministratorId = career.AdministratorId,
            }).ToList()
        };

    }

    public static Subject UpdateInfo(Subject existingInfo, Subject newInfo)
    {
        existingInfo.Name = newInfo.Name;
        existingInfo.Description = newInfo.Description;
        existingInfo.Credits = newInfo.Credits;
        existingInfo.ProfessorId = newInfo.ProfessorId;

        return existingInfo;
    }
}