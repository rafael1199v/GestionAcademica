using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Infrastructure.Mappers;

public class ProfessorMapper : IProfessorMapper
{
    
    private readonly IHashUtility _hashUtility;

    public ProfessorMapper(IHashUtility hashUtility)
    {
        _hashUtility = hashUtility;
    }
    
    public ResponseProfessorDTO ProfessorToResponseProfessor(ProfessorEntity professor)
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

    public Professor CreateProfessorDtoToProfessor(CreateProfessorDTO createProfessorDto)
    {
        
        Professor professor = new Professor
        {
            User = new User
            {
                Name = createProfessorDto.Name,
                LastName = createProfessorDto.LastName,
                Password = _hashUtility.CreateHash(createProfessorDto.Password),
                Address = createProfessorDto.Address,
                PersonalEmail = createProfessorDto.PersonalEmail,
                InstitutionalEmail = createProfessorDto.InstitutionalEmail,
                PhoneNumber = createProfessorDto.PhoneNumber,
                BirthDate = DateOnly.Parse(createProfessorDto.BirthDate),
                RoleId = (int)RoleEnum.Professor
            }

        };

        return professor;
    }

    public ProfessorDetailsDTO ProfessorEntityToProfessorDetailsDto(ProfessorEntity professor)
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