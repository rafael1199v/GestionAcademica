using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Application.DTO;
using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Application;

public class GetProfessorInformation : IGetProfessorInformation
{
    private readonly IProfessorRepository _professorRepository;


    public GetProfessorInformation(IProfessorRepository professorRepository)
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