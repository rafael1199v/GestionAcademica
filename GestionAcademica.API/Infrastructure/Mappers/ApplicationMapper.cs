using GestionAcademica.API.Application.DTOs.Applicant;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.DTOs.User;
using GestionAcademica.API.Domain.Entities;
using ApplicationModel = GestionAcademica.API.Infrastructure.Persistence.Models.Application;

namespace GestionAcademica.API.Infrastructure.Mappers;

public class ApplicationMapper
{
    public static ApplicationModel EntityToModel(ApplicationEntity application)
    {
        return new ApplicationModel
        {
            Id = application.Id,
            ApplicantId = application.ApplicantId,
            StatusId = application.StatusId,
            VacancyId = application.VacancyId
        };
    }
    public static ApplicationDTO ModelToDTO(ApplicationModel application)
    {
        return new ApplicationDTO
        {
            Id = application.Id,
            VacancyId = application.VacancyId,
            ApplicantId = application.ApplicantId,
            StatusId = application.StatusId,
            VacancyName = application.Vacancy.Name,
            VacancyDescription = application.Vacancy.Description,
            VacancyCareerName = application.Vacancy.Career.Name,
            ApplicantName = application.Applicant.User.Name + " " + application.Applicant.User.LastName,
            AdministratorName = application.Vacancy.Admin.User.Name + " " + application.Vacancy.Admin.User.LastName,
            VacancySubjectName = application.Vacancy.Subject.Name
        };
    }
    public static ApplicationDetailDTO ModelToDetailDTO(ApplicationModel application)
    {
        return new ApplicationDetailDTO
        {
            Id = application.Id,
            VacancyId = application.VacancyId,
            ApplicantId = application.ApplicantId,
            StatusId = application.StatusId,
            VacancyName = application.Vacancy.Name,
            VacancyDescription = application.Vacancy.Description,
            VacancyCareerName = application.Vacancy.Career.Name,
            ApplicantName = application.Applicant.User.Name + " " + application.Applicant.User.LastName,
            AdministratorName = application.Vacancy.Admin.User.Name + " " + application.Vacancy.Admin.User.LastName,

            Files = application.Files.Select(file => FileMapper.ModelToDTO(file))
                .ToList()
        };
    }
}