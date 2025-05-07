using GestionAcademica.API.Application.DTO;

namespace GestionAcademica.API.Application.Abstractions
{
    public interface IDetailProfessorUseCase
    {
        List<ProfessorDetailsDTO> ObtainAllProfessors();
    }
}
