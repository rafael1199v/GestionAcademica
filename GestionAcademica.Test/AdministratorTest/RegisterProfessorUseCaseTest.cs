using FakeItEasy;
using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Application.DTO;
using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;


namespace GestionAcademica.Test.AdministratorTest;
using GestionAcademica.API.Application;

public class RegisterProfessorUseCaseTest
{
    private readonly IProfessorRepository _professorRepository;
    private readonly RegisterProfessorUseCase _registerProfessorUseCase;

    public RegisterProfessorUseCaseTest()
    {
        _professorRepository = A.Fake<IProfessorRepository>();
        _registerProfessorUseCase = new RegisterProfessorUseCase(_professorRepository);
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

        A.CallTo(() => _professorRepository.Create(A<Professor>._))
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
                }
            });
        //Act

        ResponseProfessorDTO responseProfessor = _registerProfessorUseCase.CreateProffesor(professor);

        //Assert
        
        
        Assert.NotNull(responseProfessor);
        Assert.Equal(professor.Name, responseProfessor.Name);
        Assert.Equal(professor.LastName, responseProfessor.LastName);
        Assert.Equal(1, responseProfessor.Id);
        Assert.Equal(professor.PersonalEmail, responseProfessor.PersonalEmail);
        Assert.Equal(professor.InstitutionalEmail, responseProfessor.InstitutionalEmail);
        Assert.Equal(professor.Address, responseProfessor.Address);
        Assert.Equal(professor.PhoneNumber, responseProfessor.PhoneNumber);
        //Assert.Equal(professor.BirthDate, responseProfessor.BirthDate);
    }
}