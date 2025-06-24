using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Mappers;

namespace GestionAcademica.API.Application.UseCases.AdministratorUseCases;

public class ProfessorManagementUseCase : IProfessorManagementUseCase
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IUserRepository _userRepository;
    private readonly IHashUtility _hashUtility;
    
    public ProfessorManagementUseCase(IProfessorRepository professorRepository, IUserRepository userRepository, IHashUtility hashUtility)
    {
        _professorRepository = professorRepository;
        _userRepository = userRepository;
        _hashUtility = hashUtility;
    }

    public ResponseProfessorDTO RegisterProfessor(CreateProfessorDTO createProfessorDto)
    {
        ValidateEmails(createProfessorDto.InstitutionalEmail, createProfessorDto.PersonalEmail);
        
        if (!DateOnly.TryParse(createProfessorDto.BirthDate, out DateOnly birthDate))
            throw new ArgumentException("La fecha es invalida");
        
        UserEntity userEntity = new UserEntity(
            createProfessorDto.Name, 
            createProfessorDto.LastName, 
            createProfessorDto.Address, 
            createProfessorDto.PersonalEmail, 
            createProfessorDto.InstitutionalEmail, 
            _hashUtility.CreateHash(createProfessorDto.Password), 
            createProfessorDto.PhoneNumber, 
            birthDate,
            "Habilitado", 
            (int)RoleEnum.Professor
        );

        ProfessorEntity professorEntity = new ProfessorEntity
        {
            User = userEntity,
        };
        
        professorEntity.User.Name = userEntity.Name;
        professorEntity.User.LastName = userEntity.LastName;
        professorEntity.User.Address = userEntity.Address;
        professorEntity.User.PersonalEmail = userEntity.PersonalEmail;
        professorEntity.User.InstitutionalEmail = userEntity.InstitutionalEmail;
        professorEntity.User.Password = userEntity.Password;
        professorEntity.User.PhoneNumber = userEntity.PhoneNumber;
        professorEntity.User.BirthDate = userEntity.BirthDate;
        professorEntity.User.Status = userEntity.Status;
        professorEntity.User.RoleId = userEntity.RoleId;
        
        professorEntity = _professorRepository.Add(professorEntity);
        
        ResponseProfessorDTO responseProfessorDto = ToResponseProfessor(professorEntity);

        return responseProfessorDto;
    }

    public void UpdateProfessor(UpdateProfessorDTO updateProfessorDto)
    {
        ProfessorEntity professor = _professorRepository.GetById(updateProfessorDto.Id);
        
        if(professor == null)
            throw new Exception("Professor no existe");
        
        ValidateUpdateEmails(professor.UserId, updateProfessorDto.InstitutionalEmail, updateProfessorDto.PersonalEmail);

        if (!DateOnly.TryParse(updateProfessorDto.BirthDate, out DateOnly birthDate))
            throw new ArgumentException("La fecha es invalida");
        
        UserEntity userEntity = new UserEntity(
            updateProfessorDto.Name,
            updateProfessorDto.LastName,
            updateProfessorDto.Address,
            updateProfessorDto.PersonalEmail,
            updateProfessorDto.InstitutionalEmail,
            professor.User.Password,
            updateProfessorDto.PhoneNumber,
            birthDate,
            professor.User.Status,
            professor.User.RoleId
        );

        professor.User = userEntity;
        
        _professorRepository.Update(professor);
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
    
    private void ValidateEmails(string institutionalEmail, string personalEmail)
    {
        UserEntity? user = _userRepository.GetByInstitutionalEmail(institutionalEmail);

        if (user != null)
            throw new ArgumentException("El correo institucional ya esta en uso");
        
        if(!IsValidEmail(institutionalEmail))
            throw new ArgumentException("El correo institucional no es valido");
        
        if(!IsValidEmail(personalEmail))
            throw new ArgumentException("El correo personal no es valido");
    }

    private void ValidateUpdateEmails(int userId, string institutionalEmail, string personalEmail)
    {
        UserEntity? user = _userRepository.GetByInstitutionalEmail(institutionalEmail);

        if (user != null && user.Id != userId)
            throw new ArgumentException("El correo institucional ya esta en uso");
        
        if(!IsValidEmail(institutionalEmail))
            throw new ArgumentException("El correo institucional no es valido");
        
        if(!IsValidEmail(personalEmail))
            throw new ArgumentException("El correo personal no es valido");
    }
    
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;       
        }
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