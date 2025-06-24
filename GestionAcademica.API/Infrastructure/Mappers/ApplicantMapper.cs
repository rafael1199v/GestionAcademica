using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.DTOs.Applicant;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.DTOs.User;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Application.Utilities;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using ApplicationModel = GestionAcademica.API.Infrastructure.Persistence.Models.Application;

namespace GestionAcademica.API.Infrastructure.Mappers;

public class ApplicantMapper
{
    public static ApplicantDTO ExtractApplicantData(ApplicationModel data)
    {
        return new ApplicantDTO
        {
            Id = data.Applicant.Id,
            UserId = data.Applicant.User.Id,
            User = new UserDTO
            {
                Id = data.Applicant.User.Id,
                Name = data.Applicant.User.Name,
                LastName = data.Applicant.User.LastName,
                Address = data.Applicant.User.Address,
                PersonalEmail = data.Applicant.User.PersonalEmail,
                InstitutionalEmail = data.Applicant.User.InstitutionalEmail,
                PhoneNumber = data.Applicant.User.PhoneNumber,
                BirthDate = data.Applicant.User.BirthDate.ToString("O"),
                Status = data.Applicant.User.Status,
                RoleId = data.Applicant.User.RoleId,
            }
        };
    }
    public static Applicant ApplicantEntityToModel(ApplicantEntity applicantEntity)
    {
        IHashUtility hashUtility = new HashUtility();

        Applicant applicant = new Applicant
        {
            User = new User
            {
                Name = applicantEntity.User.Name,
                LastName = applicantEntity.User.LastName,
                Address = applicantEntity.User.Address,
                InstitutionalEmail = applicantEntity.User.InstitutionalEmail,
                PersonalEmail = applicantEntity.User.PersonalEmail,
                Password = hashUtility.CreateHash(applicantEntity.User.Password),
                PhoneNumber = applicantEntity.User.PhoneNumber,
                BirthDate = applicantEntity.User.BirthDate,
                Status = applicantEntity.User.Status,
                RoleId = applicantEntity.User.RoleId,
            }
        };
        
        return applicant;
    }
}