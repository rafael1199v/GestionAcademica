using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories
{
    public interface IProfessorRepository
    {
        List<ProfessorEntity> GetAllWithDetails();
        ProfessorEntity GetById(int id);
        int GetIdByUserId(int userId);
        void Update(ProfessorEntity professor);
        ProfessorEntity Add(ProfessorEntity professor);
    }
}
