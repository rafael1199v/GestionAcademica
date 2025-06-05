using GestionAcademica.API.Application.DTO;

namespace GestionAcademica.API.Application.Abstractions;

public interface IUpdateProfessorUseCase
{
    public void UpdateProfessorRun(UpdateProfessorDTO updateProfessorDTO);
}