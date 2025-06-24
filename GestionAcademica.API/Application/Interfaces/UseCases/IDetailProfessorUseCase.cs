using GestionAcademica.API.Application.DTOs.Professor;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IDetailProfessorUseCase
{
    public List<ProfessorDetailsDTO> ObtainAllProfessors();
    public ResponseProfessorDTO GetProfessorInformation(int id);
}