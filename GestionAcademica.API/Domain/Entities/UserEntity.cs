using System.Diagnostics;
using GestionAcademica.API.Domain.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace GestionAcademica.API.Domain.Entities;

public class UserEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PersonalEmail { get; set; } = null!;

    public string InstitutionalEmail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Status { get; set; } = null!;

    public int RoleId { get; set; }

    public UserEntity(string name, string lastName, string address, string personalEmail,
        string institutionalEmail, string password, string? phoneNumber, DateOnly birthDate, string status, int roleId)
    {
        this.ValidateInformation(name, lastName, address, personalEmail, institutionalEmail, password, phoneNumber, status ,birthDate);

        Id = 0;
        Name = name;
        LastName = lastName;
        Address = address;
        PersonalEmail = personalEmail;
        InstitutionalEmail = institutionalEmail;
        Password = password;
        PhoneNumber = phoneNumber;
        RoleId = roleId;
        Status = status;
        BirthDate = birthDate;
    }

    private void ValidateInformation(string name, string lastName, string address, string personalEmail,
        string institutionalEmail, string password, string? phoneNumber, string status, DateOnly birthDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("El nombre no puede esta vacio");
        
        if(string.IsNullOrWhiteSpace(lastName))
            throw new DomainException("El apellido no puede esta vacio");
        
        if(string.IsNullOrWhiteSpace(address))
            throw new DomainException("La direccion no puede esta vacia");
        
        if(string.IsNullOrWhiteSpace(personalEmail))
            throw new DomainException("El email personal no puede esta vacio");
        
        if(string.IsNullOrWhiteSpace(institutionalEmail))
            throw new DomainException("El email institucional no puede esta vacio");
        
        if(string.IsNullOrWhiteSpace(phoneNumber))
            throw new DomainException("El numero de telefono no puede esta vacio");
        
        if(phoneNumber.Length != 8)
            throw new DomainException("El numero de telefono debe tener 8 digitos");
        
        if(!phoneNumber.All(char.IsDigit))
            throw new DomainException("El numero de telefono debe contener solo numeros");
        
        if(string.IsNullOrWhiteSpace(password))
            throw new DomainException("La contraseña no puede esta vacia");
        
        if(string.IsNullOrWhiteSpace(status))
            throw new DomainException("El estado no puede esta vacio");

        if (birthDate > DateOnly.FromDateTime(DateTime.Now))
            throw new DomainException("La fecha de nacimiento no puede esta en el futuro");
    }
    
    
}