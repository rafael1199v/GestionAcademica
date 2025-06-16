using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories
{
    public interface IProfessorRepository
    {
        List<Professor> GetAll();
        List<Professor> GetAllWithDetails();
        Professor GetById(int id);
        Professor GetByUserId(int userId);
        void Update(Professor professor);
        void Delete(Professor professor);
        Professor Add(Professor professor);
    }
}
