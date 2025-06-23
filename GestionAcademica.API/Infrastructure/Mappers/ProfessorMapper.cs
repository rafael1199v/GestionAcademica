using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Infrastructure.Mappers;

public class ProfessorMapper : IProfessorMapper
{
    private readonly IHashUtility _hashUtility;

    public ProfessorMapper(IHashUtility hashUtility)
    {
        _hashUtility = hashUtility;
    }

    public static ResponseProfessorDTO ProfessorToResponseProfessor(ProfessorEntity professor)
    {
        ResponseProfessorDTO responseProfessorDto = new ResponseProfessorDTO
        {
            Id = professor.Id,
            Name = professor.User.Name,
            LastName = professor.User.LastName,
            Address = professor.User.Address,
            PersonalEmail = professor.User.PersonalEmail,
            InstitutionalEmail = professor.User.InstitutionalEmail,
            PhoneNumber = professor.User.PhoneNumber,
            BirthDate = professor.User.BirthDate.ToString("yyyy-MM-dd"),
            RolId = professor.User.RoleId
        };

        return responseProfessorDto;
    }

    public Professor CreateProfessorDtoToProfessor(CreateProfessorDTO createProfessorDto)
    {

        Professor professor = new Professor
        {
            User = new User
            {
                Name = createProfessorDto.Name,
                LastName = createProfessorDto.LastName,
                Password = _hashUtility.CreateHash(createProfessorDto.Password),
                Address = createProfessorDto.Address,
                PersonalEmail = createProfessorDto.PersonalEmail,
                InstitutionalEmail = createProfessorDto.InstitutionalEmail,
                PhoneNumber = createProfessorDto.PhoneNumber,
                BirthDate = DateOnly.Parse(createProfessorDto.BirthDate),
                RoleId = (int)RoleEnum.Professor
            }

        };

        return professor;
    }

    public static ProfessorDetailsDTO ProfessorEntityToProfessorDetailsDto(ProfessorEntity professor)
    {
        ProfessorDetailsDTO professorDetailsDto = new ProfessorDetailsDTO
        {
            Id = professor.Id,
            FullName = professor.User.Name + " " + professor.User.LastName,
            PersonalEmail = professor.User.PersonalEmail,
            InstitutionalEmail = professor.User.InstitutionalEmail,
            Address = professor.User.Address,
            PhoneNumber = professor.User.PhoneNumber,
            Status = professor.User.Status,
            subjects = new List<ClassDTO>()
        };

        return professorDetailsDto;

    }
    public static ProfessorEntity ModelToEntity(Professor professor)
    {
        return new ProfessorEntity
        {
            Id = professor.Id,
            UserId = professor.UserId,
            User = new UserEntity
            {
                Id = professor.User.Id,
                Name = professor.User.Name,
                LastName = professor.User.LastName,
                Address = professor.User.Address,
                BirthDate = professor.User.BirthDate,
                Password = professor.User.Password,
                InstitutionalEmail = professor.User.InstitutionalEmail,
                PersonalEmail = professor.User.PersonalEmail,
                PhoneNumber = professor.User.PhoneNumber,
                RoleId = professor.User.RoleId,
                Status = professor.User.Status,
            }
        };
    }

    public static Professor EntityToModel(ProfessorEntity professor)
    {
        return new Professor
        {
            Id = professor.Id,
            UserId = professor.User.Id,
            User = new User
            {
                Id = professor.User.Id,
                Name = professor.User.Name,
                LastName = professor.User.LastName,
                Address = professor.User.Address,
                BirthDate = professor.User.BirthDate,
                InstitutionalEmail = professor.User.InstitutionalEmail,
                PersonalEmail = professor.User.PersonalEmail,
                Password = professor.User.Password,
                PhoneNumber = professor.User.PhoneNumber,
                RoleId = professor.User.RoleId
            }
        };

    }
    public static Professor UpdateInfo(Professor existingInfo, ProfessorEntity newInfo)
    {
        existingInfo.User.Name = newInfo.User.Name;
        existingInfo.User.LastName = newInfo.User.LastName;
        existingInfo.User.PersonalEmail = newInfo.User.PersonalEmail;
        existingInfo.User.InstitutionalEmail = newInfo.User.InstitutionalEmail;
        existingInfo.User.Address = newInfo.User.Address;
        existingInfo.User.BirthDate = newInfo.User.BirthDate;
        existingInfo.User.PhoneNumber = newInfo.User.PhoneNumber;

        return existingInfo;
    }
}