using GestionAcademica.API.Application.DTOs;

namespace GestionAcademica.API.Application.Interfaces.UseCases
{
    public interface IDetailProfessorUseCase
    {
        List<ProfessorDetailsDTO> ObtainAllProfessors();
    }
}
