using GestionAcademica.API.Application.DTO;

namespace GestionAcademica.API.Application.Abstractions;

public interface IGetProfessorInformation
{
   public ResponseProfessorDTO GetProfessorInformationRun(int id); 
}