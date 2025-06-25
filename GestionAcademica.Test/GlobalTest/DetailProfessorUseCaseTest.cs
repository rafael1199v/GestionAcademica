using FakeItEasy;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;

namespace GestionAcademica.Test.GlobalTest;

public class DetailProfessorUseCaseTest
{
    private readonly IDetailProfessorUseCase _detailProfessorUseCase;
    public DetailProfessorUseCaseTest()
    {
        _detailProfessorUseCase = A.Fake<IDetailProfessorUseCase>();
    }
    [Fact]
    public void GetProfessorInformation_ReturnsSomething()
    {
        // Arrange
        int id = 1;
        ResponseProfessorDTO expectedResult = new ResponseProfessorDTO
        {
            Id = 1,
            Name = "María",
            LastName = "Rodríguez Gutiérrez",
            Address = "Av. Santos Dumont 789, Santa Cruz",
            PersonalEmail = "maria.rodriguez@gmail.com",
            InstitutionalEmail = "mrodriguez@universidad.edu.bo",
            PhoneNumber = "70000003",
            BirthDate = "1980-05-10"
        };
        A.CallTo(() => _detailProfessorUseCase.GetProfessorInformation(id))
            .Returns(expectedResult);
        // Act
        var result = _detailProfessorUseCase.GetProfessorInformation(id);
        // Assert
        Assert.Equal(result, expectedResult);
    }
}