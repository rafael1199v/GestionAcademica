using GestionAcademica.API.Application.DTOs;

namespace GestionAcademica.API.Application.Interfaces.UseCases
{
    public interface IRegisterProfessorUseCase
    {
        ResponseProfessorDTO CreateProffesor(CreateProfessorDTO createProfessorDto);
    }
}