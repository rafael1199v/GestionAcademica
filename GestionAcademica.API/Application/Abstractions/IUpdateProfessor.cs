using GestionAcademica.API.Application.DTO;

namespace GestionAcademica.API.Application.Abstractions;

public interface IUpdateProfessor
{
    public void UpdateProfessorRun(UpdateProfessorDTO updateProfessorDTO);
}