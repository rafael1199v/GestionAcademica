using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Application.DTO;
using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Application;

public class UpdateProfessorUseCaseUseCase : IUpdateProfessorUseCase
{
    private readonly IProfessorRepository _professorRepository;


    public UpdateProfessorUseCaseUseCase(IProfessorRepository professorRepository)
    {
        _professorRepository = professorRepository;
    }
    
    public void UpdateProfessorRun(UpdateProfessorDTO updateProfessorDTO)
    {
      
        ValidateUpdateProfessor(updateProfessorDTO);
        
        Professor? professor = _professorRepository.GetById(updateProfessorDTO.Id);
        
        if(professor == null)
            throw new Exception("Professor no existe");
        
        
        professor.User.Name = updateProfessorDTO.Name;
        professor.User.LastName = updateProfessorDTO.LastName;
        professor.User.Address = updateProfessorDTO.Address;
        professor.User.PersonalEmail = updateProfessorDTO.PersonalEmail;
        professor.User.InstitutionalEmail = updateProfessorDTO.InstitutionalEmail;
        professor.User.PhoneNumber = updateProfessorDTO.PhoneNumber;
        professor.User.BirthDate = DateOnly.Parse(updateProfessorDTO.BirthDate);
        
        _professorRepository.Update(professor);
        
    }

    private void ValidateUpdateProfessor(UpdateProfessorDTO updateProfessorDTO)
    {
        if(updateProfessorDTO == null)
            throw new Exception("Professor no existe");
        
        if(string.IsNullOrWhiteSpace(updateProfessorDTO.Name))
            throw new Exception("El nombre del profesor no puede estar vacio");

        if (string.IsNullOrWhiteSpace(updateProfessorDTO.LastName))
            throw new Exception("El apellido del profesor no puede estar vacio");
        
        if(string.IsNullOrWhiteSpace(updateProfessorDTO.Address))
            throw new Exception("La direccion del profesor no puede estar vacio");
        
        if(string.IsNullOrWhiteSpace(updateProfessorDTO.PersonalEmail))
            throw new Exception("El correo personal del profesor no puede estar vacio");
        
        if(string.IsNullOrWhiteSpace(updateProfessorDTO.InstitutionalEmail))
            throw new Exception("El correo institucional del profesor no puede estar vacio");
        
        if(string.IsNullOrWhiteSpace(updateProfessorDTO.PhoneNumber))
            throw new Exception("El numero de telefono del profesor no puede estar vacio");
        
        if(!updateProfessorDTO.PhoneNumber.All(char.IsDigit))
            throw new Exception("El numero de telefono del profesor solo puede tener digitos");
        
        if(updateProfessorDTO.PhoneNumber.Length != 8)
            throw new Exception("El numero de telefono del profesor debe tener 8 digitos");
        
        if(!DateOnly.TryParse(updateProfessorDTO.BirthDate, out DateOnly dateOnly))
            throw new Exception("El formato de fecha es incorrecto");
        
        if(dateOnly > DateOnly.FromDateTime(DateTime.Now))
            throw new Exception("La fecha de nacimiento no puede estar en el futuro");
        
        if(!IsValidEmail(updateProfessorDTO.PersonalEmail))
            throw new Exception("El correo personal es invalido");
        
        if(!IsValidEmail(updateProfessorDTO.InstitutionalEmail))
            throw new Exception("El correo institucional es invalido");
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