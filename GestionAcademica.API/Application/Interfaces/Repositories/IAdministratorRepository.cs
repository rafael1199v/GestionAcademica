using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories;

public interface IAdministratorRepository
{
    Administrator GetByUserId(int userId);
}