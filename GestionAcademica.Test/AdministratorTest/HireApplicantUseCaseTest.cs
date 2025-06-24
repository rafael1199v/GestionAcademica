using FakeItEasy;
using GestionAcademica.API.Application.DTOs.Applicant;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.UseCases.AdministratorUseCases;
using GestionAcademica.API.Domain.Enums;

namespace GestionAcademica.Test.AdministratorTest;

public class HireApplicantUseCaseTest
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly HireApplicantUseCase _hireApplicantUseCase;

    public HireApplicantUseCaseTest()
    {
        _applicationRepository = A.Fake<IApplicationRepository>();
        _hireApplicantUseCase = new HireApplicantUseCase(_applicationRepository);
    }


    [Fact]
    public void HireApplicatUseCase_HireApplicatByApplication_ApplicationWithNegativeId()
    {
        //Arrange
        int applicationId = -1;

        string expected = "Se tiene que contar con una postulación para poder aceptar a un postulante";
        
        A.CallTo(() => _applicationRepository.ChangeApplicationStatus(StatusEnum.ACCEPTED, applicationId)).DoesNothing();
        A.CallTo(() => _applicationRepository.FinishOtherApplications(applicationId)).DoesNothing();
        //Act

        var exception =
            Assert.Throws<ArgumentException>(() => _hireApplicantUseCase.HireApplicantByApplication(applicationId));
        
        //Assert
        Assert.Equal(expected, exception.Message);
    }


    [Fact]
    public void HireApplicationUseCase_HireApplicantByApplication_ApplicationWithZeroId()
    {
        //Arrange
        int applicationId = 0;

        string expected = "Se tiene que contar con una postulación para poder aceptar a un postulante";
        
        A.CallTo(() => _applicationRepository.ChangeApplicationStatus(StatusEnum.ACCEPTED, applicationId)).DoesNothing();
        A.CallTo(() => _applicationRepository.FinishOtherApplications(applicationId)).DoesNothing();
        //Act

        var exception =
            Assert.Throws<ArgumentException>(() => _hireApplicantUseCase.HireApplicantByApplication(applicationId));
        
        //Assert
        Assert.Equal(expected, exception.Message);
    }

    [Fact]
    public void HireApplicationUseCase_HireApplicantByApplication_ApplicationWithPositiveId()
    {
        //Arrange
        int applicationId = 1;

        string expected = "El aplicante no pudo ser encontrado";
        
        A.CallTo(() => _applicationRepository.ChangeApplicationStatus(StatusEnum.ACCEPTED, applicationId)).DoesNothing();
        A.CallTo(() => _applicationRepository.FinishOtherApplications(applicationId)).DoesNothing();
        A.CallTo(() => _applicationRepository.GetApplicantByApplication(applicationId))
            .Returns(new ApplicantDTO
            {
                Id = applicationId,
                UserId = 1
            });
        //Act

        var applicant = _hireApplicantUseCase.HireApplicantByApplication(applicationId);
        
        //Assert
        Assert.IsType<ApplicantDTO>(applicant);
    }
}
