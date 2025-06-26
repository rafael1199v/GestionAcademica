using GestionAcademica.API.Application.DTOs.Applicant;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.DTOs.File;
using GestionAcademica.API.Application.DTOs.User;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
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
    public static ApplicationDTO ModelToDTO(Infrastructure.Persistence.Models.Application application)
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
    public static ApplicationDetailDTO ApplicationModelToApplicationDetailDTO(Persistence.Models.Application application)
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
            VacancySubjectName = application.Vacancy.Subject.Name,
            Files = application.Files.Select(file => new FileDTO
            {
                Id = file.Id,
                Name = file.Filename,
                Description = file.FileDescription,
                Extension = file.FileExtension
            }).ToList(),
            User = new UserDTO
            {
                Id = application.Applicant.User.Id,
                Name = application.Applicant.User.Name,
                LastName = application.Applicant.User.LastName,
                Address = application.Applicant.User.Address,
                BirthDate = application.Applicant.User.BirthDate.ToString("O"),
                PersonalEmail = application.Applicant.User.PersonalEmail,
                InstitutionalEmail = application.Applicant.User.InstitutionalEmail,
                PhoneNumber = application.Applicant.User.PhoneNumber,
                Status = application.Applicant.User.Status,
                RoleId = application.Applicant.User.RoleId
            },
            Observed = application.Applicant.Applications.Any(application => application.StatusId == (int)StatusEnum.REJECTED)
        };
    }
}