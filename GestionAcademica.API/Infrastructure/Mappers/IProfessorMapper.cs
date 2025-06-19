using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Infrastructure.Mappers;

public interface IProfessorMapper
{
    ResponseProfessorDTO ProfessorToResponseProfessor(ProfessorEntity professor);
    Professor CreateProfessorDtoToProfessor(CreateProfessorDTO createProfessorDto);
    
    ProfessorDetailsDTO ProfessorEntityToProfessorDetailsDto(ProfessorEntity professor);
    
}