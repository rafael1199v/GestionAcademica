using FakeItEasy;
using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.UseCases.AdministratorUseCases;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.Test.AdministratorTest;

public class ManageVacanciesUseCaseTest
{
    
    private readonly IVacancyRepository _vacancyRepository;
    private readonly IAdministratorRepository _administratorRepository;
    private readonly ManageVacancies _manageVacancies;

    public ManageVacanciesUseCaseTest()
    {
        _vacancyRepository = A.Fake<IVacancyRepository>();
        _administratorRepository = A.Fake<IAdministratorRepository>();
        _manageVacancies =  new ManageVacancies(_vacancyRepository, _administratorRepository);
    }


    [Fact]
    public void ManageVacanciesUseCase_UpdateVacancy_InvalidStartDate()
    {
        //Arrange
        UpdateVacancyDTO updateVacancyDto = new UpdateVacancyDTO
        {
            Id = 1,
            Name = "Vacante test",
            Description = "Hola Como estas",
            EndTime = "2025-09-15T00:00:00",
            StartTime = "2025-09-",
            CareerId = 1,
            SubjectId = 1
        };

        var expectedMessage = "La fecha es invalida";
        
        //Act
        var exception = Assert.Throws<ArgumentException>(() =>  _manageVacancies.UpdateVacancy(updateVacancyDto));
        
        //Assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void ManageVacanciesUseCase_UpdateVacancy_InvalidEndDate()
    {
        //Arrange
        UpdateVacancyDTO updateVacancyDto = new UpdateVacancyDTO
        {
            Id = 1,
            Name = "Vacante test",
            Description = "Hola Como estas",
            EndTime = "2025-09-",
            StartTime = "2025-09-15T00:00:00",
            CareerId = 1,
            SubjectId = 1
        };

        var expectedMessage = "La fecha es invalida";
        
        //Act
        var exception = Assert.Throws<ArgumentException>(() =>  _manageVacancies.UpdateVacancy(updateVacancyDto));
        
        //Assert
        Assert.Equal(expectedMessage, exception.Message);
    }


    [Fact]
    public void ManageVacanciesUseCase_DeleteVacancy_CallOneTimeToRepository()
    {
        // Arrange
        int vacanyId = 1;
        A.CallTo(() => _vacancyRepository.Delete(vacanyId)).DoesNothing();
        
        //Assert 
        _manageVacancies.DeleteVacancy(vacanyId);
        
        //Assert
        A.CallTo(() => _vacancyRepository.Delete(vacanyId)).MustHaveHappenedOnceExactly();
    }


    [Fact]
    public void ManageVacanciesUseCase_GetVacancyToUpdate_NegativeVacancyId()
    {
        
        // Arrange
        int vacanyId = -1;
        string expectedMessage = "Se necesita una vacante valida para actualizar";
        
        // Act
        var exception = Assert.Throws<ArgumentException>(() =>  _manageVacancies.GetVacancyToUpdate(vacanyId));
        
        //Assert 
        Assert.Equal(expectedMessage, exception.Message);
    }
    
    [Fact]
    public void ManageVacanciesUseCase_GetVacancyToUpdate_ZeroVacancyId()
    {
        //Arrange
        int vacanyId = 0;
        string expectedMessage = "Se necesita una vacante valida para actualizar";
        
        // Act
        var exception = Assert.Throws<ArgumentException>(() =>  _manageVacancies.GetVacancyToUpdate(vacanyId));
        
        //Assert 
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void ManageVacanciesUseCase_GetVacancyToUpdate_PositiveVacancyId()
    {
        //Arrange
        int vacanyId = 1;
        
        A.CallTo(() => _vacancyRepository.GetById(vacanyId)).Returns(new Vacancy());
        //Act
        var updateVacancyDto = _manageVacancies.GetVacancyToUpdate(vacanyId);
        
        //Assert
        A.CallTo(() =>  _vacancyRepository.GetById(vacanyId)).MustHaveHappenedOnceExactly();
        Assert.IsType<UpdateVacancyDTO>(updateVacancyDto);
    }
    
    
}