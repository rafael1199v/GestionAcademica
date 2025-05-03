using GestionAcademica.API.Application.DTO;

namespace GestionAcademica.API.Application.Abstractions
{
    public interface IRegisterProfessorUseCase
    {
        void CreateProffesor(ProfessorDTO professorDTO);
    }
}