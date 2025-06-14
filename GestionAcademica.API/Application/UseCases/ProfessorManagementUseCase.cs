using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.Mappers;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Application.UseCases;

public class ProfessorManagementUseCase : IProfessorManagementUseCase
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProfessorMapper _professorMapper;
    
    public ProfessorManagementUseCase(IProfessorRepository professorRepository, IUserRepository userRepository, IProfessorMapper professorMapper)
    {
        _professorRepository = professorRepository;
        _userRepository = userRepository;
        _professorMapper = professorMapper;
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
            createProfessorDto.Password, 
            createProfessorDto.PhoneNumber, 
            birthDate,
            "Habilitado", 
            (int)RoleEnum.Professor
        );
        
        Professor professorModel = _professorMapper.CreateProfessorDtoToProfessor(createProfessorDto);
        
        professorModel.User.Name = userEntity.Name;
        professorModel.User.LastName = userEntity.LastName;
        professorModel.User.Address = userEntity.Address;
        professorModel.User.PersonalEmail = userEntity.PersonalEmail;
        professorModel.User.InstitutionalEmail = userEntity.InstitutionalEmail;
        professorModel.User.Password = userEntity.Password;
        professorModel.User.PhoneNumber = userEntity.PhoneNumber;
        professorModel.User.BirthDate = userEntity.BirthDate;
        professorModel.User.Status = userEntity.Status;
        professorModel.User.RoleId = userEntity.RoleId;
        
        professorModel = _professorRepository.Add(professorModel);
        
        ResponseProfessorDTO responseProfessorDto = _professorMapper.ProfessorToResponseProfessor(professorModel);

        return responseProfessorDto;
    }

    public void UpdateProfessor(UpdateProfessorDTO updateProfessorDto)
    {
        // Obtener el modelo de la base de datos
        Professor? professor = _professorRepository.GetById(updateProfessorDto.Id);
        
        if(professor == null)
            throw new Exception("Professor no existe");
        
        ValidateEmails(updateProfessorDto.InstitutionalEmail, updateProfessorDto.PersonalEmail);

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
        
        professor.User.Name = userEntity.Name;
        professor.User.LastName = userEntity.LastName;
        professor.User.Address = userEntity.Address;
        professor.User.PersonalEmail = userEntity.PersonalEmail;
        professor.User.InstitutionalEmail = userEntity.InstitutionalEmail;
        professor.User.PhoneNumber = userEntity.PhoneNumber;
        professor.User.BirthDate = userEntity.BirthDate;
        
        _professorRepository.Update(professor);
    }

    public List<ProfessorDetailsDTO> ObtainAllProfessors()
    {
        List<Professor> list = _professorRepository.GetAllWithDetails();
        List<ProfessorDetailsDTO> result = new List<ProfessorDetailsDTO>();

        foreach (var item in list)
        {
            result.Add(_professorMapper.ProfessorToProfessorDetailsDto(item));
        }

        return result;
    }

    public ResponseProfessorDTO GetProfessorInformation(int id)
    {
        Professor professor = _professorRepository.GetById(id);
        return _professorMapper.ProfessorToResponseProfessor(professor);
    }
    
    private void ValidateEmails(string institutionalEmail, string personalEmail)
    {
        User? user = _userRepository.GetByInstitutionalEmail(institutionalEmail);

        if (user != null)
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
}