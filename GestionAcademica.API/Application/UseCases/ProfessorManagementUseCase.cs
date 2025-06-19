using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Mappers;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.UseCases;

public class ProfessorManagementUseCase : IProfessorManagementUseCase
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProfessorMapper _professorMapper;
    private readonly IHashUtility _hashUtility;
    
    public ProfessorManagementUseCase(IProfessorRepository professorRepository, IUserRepository userRepository, IProfessorMapper professorMapper, IHashUtility hashUtility)
    {
        _professorRepository = professorRepository;
        _userRepository = userRepository;
        _professorMapper = professorMapper;
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
        
        ResponseProfessorDTO responseProfessorDto = _professorMapper.ProfessorToResponseProfessor(professorEntity);

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
        List<ProfessorDetailsDTO> result = new List<ProfessorDetailsDTO>();

        foreach (var item in list)
        {
            result.Add(_professorMapper.ProfessorEntityToProfessorDetailsDto(item));
        }

        return result;
    }

    public ResponseProfessorDTO GetProfessorInformation(int id)
    {
        ProfessorEntity professor = _professorRepository.GetById(id);
        return _professorMapper.ProfessorToResponseProfessor(professor);
    }
    
    private void ValidateEmails(string institutionalEmail, string personalEmail)
    {
        UserEntity? user = _userRepository.GetByInstitutionalEmail(institutionalEmail);

        if (user != null)
            throw new ArgumentException("El correo institucional ya esta en uso");
        
        user = _userRepository.GetByEmail(personalEmail);

        if (user != null)
            throw new ArgumentException("El correo personal ya esta en uso");
        
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
        
        user = _userRepository.GetByEmail(personalEmail);

        if (user != null && user.Id != userId)
            throw new ArgumentException("El correo personal ya esta en uso");
        
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
}