using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories;

public interface IUserRepository
{
    UserEntity GetById(int id);
    UserEntity? GetByInstitutionalEmail(string institutionalEmail);
    public UserEntity? GetByEmail(string Email);
}