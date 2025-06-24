using FakeItEasy;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Enums;

namespace GestionAcademica.Test.GlobalTest;

public class LoginUseCaseTest
{
    private readonly ILoginUseCase _loginUseCase;
    private readonly IHashUtility _hashUtility;
    private readonly IUserRepository _userRepository;
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IProfessorRepository _professorRepository;
    private readonly IHrRepository _hrRepository;

    public LoginUseCaseTest()
    {
        _loginUseCase = A.Fake<ILoginUseCase>();
        _userRepository = A.Fake<IUserRepository>();
        _hashUtility = A.Fake<IHashUtility>();
        _administratorRepository = A.Fake<IAdministratorRepository>();
        _applicantRepository = A.Fake<IApplicantRepository>();
        _professorRepository = A.Fake<IProfessorRepository>();
        _hrRepository = A.Fake<IHrRepository>();
    }
    [Fact]
    public void Login_Returns()
    {
        // Arrange
        string emailInput = "";
        string passwordInput = "";
        (string, string, string) expectedResult = ("", "", "");

        A.CallTo(() => _loginUseCase.Login(emailInput, passwordInput))
            .Returns(expectedResult);

        // Act
        var result = _loginUseCase.Login(emailInput, passwordInput);

        // Assert
        Assert.Equal(expectedResult, result);
        A.CallTo(() => _loginUseCase.Login(emailInput, passwordInput))
            .MustHaveHappenedOnceExactly();
    }
}