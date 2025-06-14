using GestionAcademica.API.Application.DTOs;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IProfessorManagementUseCase
{
    //Create
    ResponseProfessorDTO RegisterProfessor(CreateProfessorDTO createProfessorDto);
    
    //Update
    void UpdateProfessor(UpdateProfessorDTO updateProfessorDto);
    
    //Get All
    List<ProfessorDetailsDTO> ObtainAllProfessors();
    
    //Get
    ResponseProfessorDTO GetProfessorInformation(int id);
}