using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using GestionAcademica.API.Domain.Entities;

namespace GestionAcademica.API.Infrastructure.Mappers;

public class UserMapper
{ 
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
}