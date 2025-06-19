using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Infrastructure.Mappers;

public interface IProfessorMapper
{
    ResponseProfessorDTO ProfessorToResponseProfessor(Professor professor);
    Professor CreateProfessorDtoToProfessor(CreateProfessorDTO createProfessorDto);
    
    ProfessorDetailsDTO ProfessorToProfessorDetailsDto(Professor professor);
    
}