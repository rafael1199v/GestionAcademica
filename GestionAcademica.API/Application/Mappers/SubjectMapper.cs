using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.DTOs.Career;
using GestionAcademica.API.Application.DTOs.Subject;
using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Application.Mappers;

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
}