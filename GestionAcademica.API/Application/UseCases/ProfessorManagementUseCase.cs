using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Infrastructure.Persistance.Context;

namespace GestionAcademica.API.Application.UseCases;

public class ProfessorManagementUseCase : IProfessorManagementUseCase
{
    private readonly GestionAcademicaContext _context;

    public ProfessorManagementUseCase(GestionAcademicaContext context)
    {
        _context = context;
    }
    
    public ResponseProfessorDTO CreateProfessor(CreateProfessorDTO createProfessorDto)
    {
        throw new NotImplementedException();
    }

    public void UpdateProfessor(UpdateProfessorDTO updateProfessorDto)
    {
        throw new NotImplementedException();
    }

    public List<ProfessorDetailsDTO> ObtainAllProfessors()
    {
        throw new NotImplementedException();
    }

    public ResponseProfessorDTO GetProfessorInformation(int id)
    {
        throw new NotImplementedException();
    }
}