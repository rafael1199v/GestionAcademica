using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.DTOs.Professor;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IProfessorManagementUseCase
{
    ResponseProfessorDTO RegisterProfessor(CreateProfessorDTO createProfessorDto);
    
    void UpdateProfessor(UpdateProfessorDTO updateProfessorDto);
}