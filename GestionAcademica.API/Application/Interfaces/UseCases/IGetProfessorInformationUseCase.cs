using GestionAcademica.API.Application.DTOs;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IGetProfessorInformationUseCase
{
   public ResponseProfessorDTO GetProfessorInformationRun(int id); 
}