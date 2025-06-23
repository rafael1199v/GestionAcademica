using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Application.Interfaces.Utilities;

namespace GestionAcademica.API.Infrastructure.Mappers;

public class UserMapper : IUserMapper
{
    private readonly IHashUtility _hashUtility;
    public UserMapper(IHashUtility hashUtility)
    {
        _hashUtility = hashUtility;
    }
    public static UserEntity UserModelToEntity(User user)
    {
        return new UserEntity
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            Address = user.Address,
            PersonalEmail = user.PersonalEmail,
            InstitutionalEmail = user.InstitutionalEmail,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber,
            BirthDate = user.BirthDate,
            Status = user.Status,
            RoleId = user.RoleId
        };
    }

    public UserEntity CreateProfessorDTOToUserEntity(CreateProfessorDTO dTO, DateOnly birthDate)
    {
        return new UserEntity(
            dTO.Name, 
            dTO.LastName, 
            dTO.Address, 
            dTO.PersonalEmail, 
            dTO.InstitutionalEmail, 
            _hashUtility.CreateHash(dTO.Password), 
            dTO.PhoneNumber, 
            birthDate,
            "Habilitado", 
            (int)RoleEnum.Professor
        );
    }
}