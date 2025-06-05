using GestionAcademica.API.Application.DTO;

namespace GestionAcademica.API.Application.Abstractions;

public interface IGetProfessorInformationUseCase
{
   public ResponseProfessorDTO GetProfessorInformationRun(int id); 
}