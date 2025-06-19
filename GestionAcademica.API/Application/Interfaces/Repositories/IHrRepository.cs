using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories
{
    public interface IHrRepository
    {
        // Hr GetById(int id);
        int GetIdByUserId(int userId);
    }
}