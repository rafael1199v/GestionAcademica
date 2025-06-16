using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.UseCases
{
    public interface ICreateSubjectUseCase
    {
        void CreateSubject(Subject subject);
    }
}
