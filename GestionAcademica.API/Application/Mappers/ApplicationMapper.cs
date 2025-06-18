using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.Interfaces.Mappers;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Mappers;

public class ApplicationMapper : IApplicationMapper
{
    public ApplicationDTO AppToDto(Infrastructure.Persistence.Models.Application app)
    {
        try
        {
            return new ApplicationDTO
            {
                VacancyName = app.Vacancy.Name,
                VacancyDesc = app.Vacancy.Description,
                Status = app.Status.Name,
                ApplicantName = app.Applicant.User.Name + " " + app.Applicant.User.LastName,
                OwnerName = app.Vacancy.Admin.User.Name + " " + app.Vacancy.Admin.User.LastName,
                FileQtty = /*app.Files.Count,*/0,
                // Files = app.Files,
                Id = app.Id,
                VacancyId = app.VacancyId,
                StatusId = app.StatusId,
                ApplicantId = app.ApplicantId,
                OwnerId = app.Vacancy.AdminId
            };
        }
        catch
        {
            throw new ApplicationException("Error al mapear la solicitud a DTO. Verifique los datos de entrada.");
        }
    }

    public Infrastructure.Persistence.Models.Application DtoToApp(ApplicationDTO dto)
    {
        return new Infrastructure.Persistence.Models.Application
        {
            Id = dto.Id,
            VacancyId = dto.VacancyId,
            ApplicantId = dto.ApplicantId,
            StatusId = dto.StatusId,
            Vacancy = new Vacancy
            {
                Id = dto.VacancyId,
                Name = dto.VacancyName,
                Description = dto.VacancyDesc
            },
            Applicant = new Applicant
            {
                Id = dto.ApplicantId,
                User = new User
                {
                    Name = dto.ApplicantName.Split(' ')[0],
                    LastName = dto.ApplicantName.Split(' ')[1]
                }
            },
            Status = new Status
            {
                Id = dto.StatusId,
                Name = dto.Status
            },
            Files = [] // Assuming files are handled separately
        };
    }
}