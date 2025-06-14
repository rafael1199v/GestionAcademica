using GestionAcademica.API.Application.DTOs;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IUpdateProfessorUseCase
{
    public void UpdateProfessorRun(UpdateProfessorDTO updateProfessorDTO);
}