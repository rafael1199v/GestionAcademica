using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Mappers;

namespace GestionAcademica.API.Application.UseCases.AdministratorUseCases;

public class DetailProfessorUseCase : IDetailProfessorUseCase
{
    private readonly IProfessorRepository _professorRepository;
    
    public DetailProfessorUseCase(IProfessorRepository professorRepository)
    {
        _professorRepository = professorRepository;
    }

    public List<ProfessorDetailsDTO> ObtainAllProfessors()
    {
        List<ProfessorEntity> list = _professorRepository.GetAllWithDetails();
        List<ProfessorDetailsDTO> result = list.Select(professor => ToProfessorDetailsDTO(professor)).ToList();
        
        return result;
    }

    public ResponseProfessorDTO GetProfessorInformation(int id)
    {
        ProfessorEntity professor = _professorRepository.GetById(id);
        return ToResponseProfessor(professor);
    }
    
    private ResponseProfessorDTO ToResponseProfessor(ProfessorEntity professor)
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
            BirthDate = professor.User.BirthDate.ToString("yyyy-MM-dd"),
            RolId = professor.User.RoleId
        };

        return responseProfessorDto;
    }

    private ProfessorDetailsDTO ToProfessorDetailsDTO(ProfessorEntity professor)
    {
        ProfessorDetailsDTO professorDetailsDto = new ProfessorDetailsDTO
        {
            Id = professor.Id,
            FullName = professor.User.Name + " " + professor.User.LastName,
            PersonalEmail = professor.User.PersonalEmail,
            InstitutionalEmail = professor.User.InstitutionalEmail,
            Address = professor.User.Address,
            PhoneNumber = professor.User.PhoneNumber,
            Status = professor.User.Status,
            subjects = new List<ClassDTO>()
        };

        return professorDetailsDto;
    }
}