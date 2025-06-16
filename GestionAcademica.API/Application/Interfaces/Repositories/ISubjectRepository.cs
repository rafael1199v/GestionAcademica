using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories
{
    public interface ISubjectRepository
    {
        Subject GetById(int id);
        List<Subject> GetAll();
        void Create(Subject subject);
        void Delete(Subject subject);
        void Update(Subject subject);
        List<Subject> GetWithCareers();
    }
}
