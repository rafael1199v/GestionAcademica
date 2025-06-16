using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Mappers;

public interface IProfessorMapper
{
    ResponseProfessorDTO ProfessorToResponseProfessor(Professor professor);
    Professor CreateProfessorDtoToProfessor(CreateProfessorDTO createProfessorDto);
    
    ProfessorDetailsDTO ProfessorToProfessorDetailsDto(Professor professor);
    
}