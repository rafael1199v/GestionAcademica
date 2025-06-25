using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories;

public interface IAdministratorRepository
{
    int GetIdByUserId(int userId);
}