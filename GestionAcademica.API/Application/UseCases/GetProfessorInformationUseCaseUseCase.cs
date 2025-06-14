using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Application.UseCases;

public class GetProfessorInformationUseCaseUseCase : IGetProfessorInformationUseCase
{
    private readonly IProfessorRepository _professorRepository;


    public GetProfessorInformationUseCaseUseCase(IProfessorRepository professorRepository)
    {
        _professorRepository = professorRepository;
    }
    
    public ResponseProfessorDTO GetProfessorInformationRun(int id)
    {
        Professor professor = _professorRepository.GetById(id);

        return this.MapProfessorToResponseProfessor(professor);
    }
    private ResponseProfessorDTO MapProfessorToResponseProfessor(Professor professor)
    {
        ResponseProfessorDTO responseProfessorDto = new ResponseProfessorDTO
        {
            Id = professor.Id,
            Name = professor.User.Name,
            LastName = professor.User.LastName,
            Address = professor.User.Address,
            PersonalEmail = professor.User.PersonalEmail,
            InstitutionalEmail = professor.User.InstitutionalEmail,
            PhoneNumber = professor.User.PhoneNumber,
            BirthDate = professor.User.BirthDate.ToString(),
            RolId = professor.User.RoleId
        };
            
        return responseProfessorDto;
    }
    
    
}