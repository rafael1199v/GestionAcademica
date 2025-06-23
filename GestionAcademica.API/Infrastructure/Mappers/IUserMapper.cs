using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Infrastructure.Mappers;

public interface IUserMapper
{
    UserEntity CreateProfessorDTOToUserEntity(CreateProfessorDTO dTO, DateOnly birthDate);
}