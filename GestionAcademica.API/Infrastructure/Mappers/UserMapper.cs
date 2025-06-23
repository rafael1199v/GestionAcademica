using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Persistence.Models;

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

    public static User UserEntityToModel(UserEntity user)
    {
        return new User
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