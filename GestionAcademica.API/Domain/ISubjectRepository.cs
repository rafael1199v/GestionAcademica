using GestionAcademica.API.Models;

namespace GestionAcademica.API.Domain
{
    public interface ISubjectRepository
    {
        Subject GetById(int id);
        List<Subject> GetAll();
        void Create(Subject subject);
        void Delete(Subject subject);
        void Update(Subject subject);
    }
}
