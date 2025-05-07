using GestionAcademica.API.Models;

namespace GestionAcademica.API.Domain
{
    public interface IProfessorRepository
    {
        List<Professor> GetAll();
        List<Professor> GetAllWithDetails();
        Professor GetById(int id);
        void Update(Professor professor);
        void Delete(Professor professor);
        Professor Create(Professor professor);
    }
}
