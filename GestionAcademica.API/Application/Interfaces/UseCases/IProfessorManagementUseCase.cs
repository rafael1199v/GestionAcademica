using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.DTOs.Professor;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IProfessorManagementUseCase
{
    //Create
    ResponseProfessorDTO RegisterProfessor(CreateProfessorDTO createProfessorDto);
    
    //Update
    void UpdateProfessor(UpdateProfessorDTO updateProfessorDto);
}