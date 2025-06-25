using FakeItEasy;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.UseCases.ApplicantUseCases;
using GestionAcademica.API.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace GestionAcademica.Test.ApplicationTest;

public class ApplyForVacancyTest
{
    private readonly IVacancyRepository _vacancyRepository;
    private readonly IUploadFilesUseCase _uploadFilesUseCase;
    private readonly IApplicationRepository _applicationRepository;
    private readonly ApplyForVacancy _applyForVacancy;

    public ApplyForVacancyTest()
    {
        _vacancyRepository = A.Fake<IVacancyRepository>();
        _uploadFilesUseCase = A.Fake<IUploadFilesUseCase>();
        _applicationRepository = A.Fake<IApplicationRepository>();
        _applyForVacancy = new ApplyForVacancy(_vacancyRepository, _uploadFilesUseCase, _applicationRepository);
    }


    [Fact]
    public void ApplyForVacancy_GetAvailableVacancies_ExecuteOneTime()
    {
        //Arrange
        int applicantId = 1;

        A.CallTo(() => _vacancyRepository.GetForApplicants(applicantId))
            .Returns(new List<VacancyDTO>());
        
        //Act
        _applyForVacancy.GetAvailableVacancies(applicantId);
        
        //Assert
        A.CallTo(() => _vacancyRepository.GetForApplicants(applicantId)).MustHaveHappenedOnceExactly();
    }


    [Fact]
    public void ApplyForVacancy_Apply_DoesNotExistFiles()
    {
        //Arrange
        var createApplicationDto = new CreateApplicationDTO
        {
            VacancyId = 1,
            ApplicantId = 1,
            StatusId = 1,
            Files = null
        };

        A.CallTo(() => _applicationRepository.Add(new ApplicationEntity()))
            .Returns(1);

        int applicationId = 1;
        
        A.CallTo(() => _uploadFilesUseCase.Uploadfiles(createApplicationDto.Files, applicationId)).DoesNothing();
        string expected = "Se necesita subir por lo menos un archivo";
        
        //Act
        var exception = Assert.Throws<ArgumentException>(() => _applyForVacancy.Apply(createApplicationDto));
        
        //Assert
        Assert.Equal(expected, exception.Message);
    }

    [Fact]
    public void ApplyForVacancy_Apply_MoreThanSixFiles()
    {
        var createApplicationDto = new CreateApplicationDTO
        {
            VacancyId = 1,
            ApplicantId = 1,
            StatusId = 1,
            Files = new List<IFormFile>()
            {
                new FormFile(new MemoryStream(), 0, 10, "file", "file1.txt"),
                new FormFile(new MemoryStream(), 0, 10, "file", "file1.txt"),
                new FormFile(new MemoryStream(), 0, 10, "file", "file1.txt"),
                new FormFile(new MemoryStream(), 0, 10, "file", "file1.txt"),
                new FormFile(new MemoryStream(), 0, 10, "file", "file1.txt"),
                new FormFile(new MemoryStream(), 0, 10, "file", "file1.txt"),
                new FormFile(new MemoryStream(), 0, 10, "file", "file1.txt")
            }
        };

        A.CallTo(() => _applicationRepository.Add(new ApplicationEntity()))
            .Returns(1);

        int applicationId = 1;
        
        A.CallTo(() => _uploadFilesUseCase.Uploadfiles(createApplicationDto.Files, applicationId)).DoesNothing();
        string expected = "Se pueden subir maximo 6 archivos para una postulacion";
        
        //Act
        var exception = Assert.Throws<ArgumentException>(() => _applyForVacancy.Apply(createApplicationDto));
        
        //Assert
        Assert.Equal(expected, exception.Message);
    }
}