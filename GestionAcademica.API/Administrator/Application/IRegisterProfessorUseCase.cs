using GestionAcademica.API.DTO;

namespace GestionAcademica.API.Administrator.Application
{
    public interface IRegisterProfessorUseCase
    {
        void CreateProffesor(ProfessorDTO professorDTO);
    }
}