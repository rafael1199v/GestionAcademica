using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Application.Interfaces.UseCases
{
    public interface ICreateSubjectUseCase
    {
        void CreateSubject(Subject subject);
    }
}
