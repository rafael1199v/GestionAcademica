using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories
{
    public interface IProfessorRepository
    {
        List<Professor> GetAll();
        List<Professor> GetAllWithDetails();
        Professor GetById(int id);
        void Update(Professor professor);
        void Delete(Professor professor);
        Professor Add(Professor professor);
    }
}
