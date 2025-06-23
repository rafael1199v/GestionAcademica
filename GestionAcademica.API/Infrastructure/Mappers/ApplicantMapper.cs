using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.DTOs.Applicant;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.DTOs.User;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using ApplicationModel = GestionAcademica.API.Infrastructure.Persistence.Models.Application;

namespace GestionAcademica.API.Infrastructure.Mappers;

public class ApplicantMapper : IApplicantMapper
{
    private readonly IHashUtility _hashUtility;

    public ApplicantMapper(IHashUtility hashUtility)
    {
        _hashUtility = hashUtility;
    }
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
    public Applicant CreateUserDTOToModel(CreateUserDTO user)
        {
            return new Applicant
            {
                User = new User
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Password = _hashUtility.CreateHash(user.Password),
                    Address = user.Address,
                    PersonalEmail = user.Email,
                    InstitutionalEmail = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    BirthDate = DateOnly.Parse(user.BirthDate),
                    RoleId = (int)RoleEnum.Applicant
                }
            };
        }
}