using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories
{
    public interface IHrRepository
    {
        Hr GetById(int id);
        Hr GetByUserId(int userId);
    }
}