using FakeItEasy;
using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Application.Mappers;
using GestionAcademica.API.Application.UseCases;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Domain.Exceptions;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.Test.AdministratorTest;


public class RegisterProfessorUseCaseTest
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IUserRepository _userRepository;
    private readonly IHashUtility _hashUtility;
    private readonly ProfessorManagementUseCase _professorManagementUseCase;
    
    public RegisterProfessorUseCaseTest()
    {
        _professorRepository = A.Fake<IProfessorRepository>();
        _userRepository = A.Fake<IUserRepository>();
        _hashUtility = A.Fake<IHashUtility>();
        _professorManagementUseCase = new ProfessorManagementUseCase(_professorRepository, _userRepository, new ProfessorMapper(_hashUtility));
    }
    
    [Fact]
    public void RegisterProfessorUseCase_CreateProfessor_ReturnDTO()
    {
        //Arrange
        CreateProfessorDTO professor = new CreateProfessorDTO
        {
            Name = "Rafael",
            LastName = "Vargas",
            Password = "123",
            PersonalEmail = "rafael@gmail.com",
            InstitutionalEmail = "rafael@ucb.edu.bo",
            Address = "Av tres pasos al frente",
            PhoneNumber = "12345678",
            BirthDate = "2005-04-5",
        };

        ResponseProfessorDTO expected = new ResponseProfessorDTO
        {
            Id = 1,
            Name = "Rafael",
            LastName = "Vargas",
            PersonalEmail = "rafael@gmail.com",
            InstitutionalEmail = "rafael@ucb.edu.bo",
            Address = "Av tres pasos al frente",
            PhoneNumber = "12345678",
            BirthDate = "2005-04-5",
            RolId = (int) RoleEnum.Professor,
        };

        A.CallTo(() => _professorRepository.Add(A<Professor>._))
            .Returns(new Professor
            {
                Id = 1,
                UserId = 1,
                User = new User
                {
                    Id = 1,
                    Name = professor.Name,
                    LastName = professor.LastName,
                    Password = professor.Password,
                    PersonalEmail = professor.PersonalEmail,
                    InstitutionalEmail = professor.InstitutionalEmail,
                    Address = professor.Address,
                    PhoneNumber = professor.PhoneNumber,
                    BirthDate = DateOnly.Parse(professor.BirthDate),
                    RoleId = (int) RoleEnum.Professor
                }
            });

        A.CallTo(() => _userRepository.GetByInstitutionalEmail(A<string>._))
            .Returns(null);
        
        //Act
        ResponseProfessorDTO responseProfessor = _professorManagementUseCase.RegisterProfessor(professor);

        //Assert
        Assert.NotNull(responseProfessor);
        
        Assert.Equal(expected.Id, responseProfessor.Id);
        Assert.Equal(expected.Name, responseProfessor.Name);
        Assert.Equal(expected.LastName, responseProfessor.LastName);
        Assert.Equal(expected.PersonalEmail, responseProfessor.PersonalEmail);
        Assert.Equal(expected.InstitutionalEmail, responseProfessor.InstitutionalEmail);
        Assert.Equal(expected.Address, responseProfessor.Address);
        Assert.Equal(expected.PhoneNumber, responseProfessor.PhoneNumber);
        Assert.Equal(DateOnly.Parse(expected.BirthDate), DateOnly.Parse(responseProfessor.BirthDate));
        Assert.Equal(expected.RolId, responseProfessor.RolId);
    }


    [Fact]
    public void RegisterProfessorUseCase_CreateProfessor_ExistingEmail()
    {
        CreateProfessorDTO professor = new CreateProfessorDTO
        {
            Name = "Rafael",
            LastName = "Vargas",
            Password = "123",
            PersonalEmail = "rafael@gmail.com",
            InstitutionalEmail = "rafael@ucb.edu.bo",
            Address = "Av tres pasos al frente",
            PhoneNumber = "12345678",
            BirthDate = "2005-04-5",
        };
        
        A.CallTo(() => _userRepository.GetByInstitutionalEmail(A<string>._))
            .Returns(new User());
        
        string expected = "El correo institucional ya esta en uso";
        
        var exception = Assert.Throws<ArgumentException>(() => _professorManagementUseCase.RegisterProfessor(createProfessorDto: professor));
         Assert.Equal(expected, exception.Message);
        
    }
    
    
    [Fact]
    public void RegisterProfessorUseCase_CreateProfessor_InvalidDate()
    {
        CreateProfessorDTO professor = new CreateProfessorDTO
        {
            Name = "Rafael",
            LastName = "Vargas",
            Password = "123",
            PersonalEmail = "rafael@gmail.com",
            InstitutionalEmail = "rafael@ucb.edu.bo",
            Address = "Av tres pasos al frente",
            PhoneNumber = "12345678",
            BirthDate = "asdasdasd",
        };
        
        A.CallTo(() => _userRepository.GetByInstitutionalEmail(A<string>._))
            .Returns(null);
        
        string expected = "La fecha es invalida";
        
        var exception = Assert.Throws<ArgumentException>(() => _professorManagementUseCase.RegisterProfessor(createProfessorDto: professor));
        Assert.Equal(expected, exception.Message);
        
    }
    
    [Fact]
    public void RegisterProfessorUseCase_CreateProfessor_FutureDate()
    {
        CreateProfessorDTO professor = new CreateProfessorDTO
        {
            Name = "Rafael",
            LastName = "Vargas",
            Password = "123",
            PersonalEmail = "rafael@gmail.com",
            InstitutionalEmail = "rafael@ucb.edu.bo",
            Address = "Av tres pasos al frente",
            PhoneNumber = "12345678",
            BirthDate = "2026-01-01",
        };
        
        A.CallTo(() => _userRepository.GetByInstitutionalEmail(A<string>._))
            .Returns(null);
        
        string expected = "La fecha de nacimiento no puede esta en el futuro";
        
        var exception = Assert.Throws<DomainException>(() => _professorManagementUseCase.RegisterProfessor(createProfessorDto: professor));
        Assert.Equal(expected, exception.Message);
        
    }
    
}
