using System.Linq.Expressions;
using FakeItEasy;
using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Application.DTO;
using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;
using GestionAcademica.API.Application;
using GestionAcademica.API.Application.Enums;

namespace GestionAcademica.Test.AdministratorTest;


public class RegisterProfessorUseCaseTest
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IUserRepository _userRepository;
    private readonly RegisterProfessorUseCase _registerProfessorUseCase;

    public RegisterProfessorUseCaseTest()
    {
        _professorRepository = A.Fake<IProfessorRepository>();
        _userRepository = A.Fake<IUserRepository>();
        _registerProfessorUseCase = new RegisterProfessorUseCase(_professorRepository, _userRepository);
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
        ResponseProfessorDTO responseProfessor = _registerProfessorUseCase.CreateProffesor(professor);

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

        var userList = new List<User> { new User() }.AsQueryable();

        A.CallTo(() => _userRepository.GetByInstitutionalEmail(A<string>._))
            .Returns(new User());
        
        string expected = "El correo institutional ya existe";
        
        var exception = Assert.Throws<ArgumentException>(() => _registerProfessorUseCase.CreateProffesor(createProfessorDto: professor));
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

        var userList = new List<User> { new User() }.AsQueryable();

        A.CallTo(() => _userRepository.GetByInstitutionalEmail(A<string>._))
            .Returns(null);
        
        string expected = "El formato de fecha es incorrecto";
        
        var exception = Assert.Throws<ArgumentException>(() => _registerProfessorUseCase.CreateProffesor(createProfessorDto: professor));
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

        var userList = new List<User> { new User() }.AsQueryable();

        A.CallTo(() => _userRepository.GetByInstitutionalEmail(A<string>._))
            .Returns(null);
        
        string expected = "La fecha de nacimiento no puede estar en el futuro";
        
        var exception = Assert.Throws<ArgumentException>(() => _registerProfessorUseCase.CreateProffesor(createProfessorDto: professor));
        Assert.Equal(expected, exception.Message);
        
    }
    
}
