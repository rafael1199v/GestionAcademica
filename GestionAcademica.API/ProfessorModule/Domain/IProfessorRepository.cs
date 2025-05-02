using GestionAcademica.API.Models;

namespace GestionAcademica.API.ProfessorModule.Domain
{
    public interface IProfessorRepository
    {
        List<Professor> GetAll();
        Professor GetById(int id);
        void Update(Professor professor);
        void Delete(Professor professor);
        void Create(Professor professor);
    }
}
