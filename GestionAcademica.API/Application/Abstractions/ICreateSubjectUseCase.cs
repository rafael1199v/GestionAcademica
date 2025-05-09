using GestionAcademica.API.Models;

namespace GestionAcademica.API.Application.Abstractions
{
    public interface ICreateSubjectUseCase
    {
        void CreateSubject(Subject subject);
    }
}
