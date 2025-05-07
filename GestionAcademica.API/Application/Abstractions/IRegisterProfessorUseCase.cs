using GestionAcademica.API.Application.DTO;

namespace GestionAcademica.API.Application.Abstractions
{
    public interface IRegisterProfessorUseCase
    {
        ResponseProfessorDTO CreateProffesor(CreateProfessorDTO createProfessorDto);
    }
}