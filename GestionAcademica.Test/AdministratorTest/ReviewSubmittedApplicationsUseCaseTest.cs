using FakeItEasy;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.UseCases.AdministratorUseCases;
using GestionAcademica.API.Domain.Enums;

namespace GestionAcademica.Test.AdministratorTest;

public class ReviewSubmittedApplicationsUseCaseTest
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly ReviewSubmittedApplicationsUseCase _reviewSubmittedApplicationsUseCase;

    public ReviewSubmittedApplicationsUseCaseTest()
    {
        _applicationRepository = A.Fake<IApplicationRepository>();
        _reviewSubmittedApplicationsUseCase = new ReviewSubmittedApplicationsUseCase(_applicationRepository);
    }

    [Fact]
    public void GetInterviewApplications_ValidVacancyId_ReturnsApplications()
    {
        // Arrange
        int vacancyId = 1;
        var expectedApplications = new List<ApplicationDTO>
        {
            new ApplicationDTO { Id = 101 },
            new ApplicationDTO { Id = 102 }
        };

        A.CallTo(() => _applicationRepository.GetApplicationsForAdministrator(vacancyId))
            .Returns(expectedApplications);

        // Act
        var result = _reviewSubmittedApplicationsUseCase.GetInterviewApplications(vacancyId);

        // Assert
        Assert.Equal(expectedApplications, result);
        A.CallTo(() => _applicationRepository.GetApplicationsForAdministrator(vacancyId))
            .MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void GetInterviewApplications_EmptyResult_ReturnsEmptyList()
    {
        // Arrange
        int vacancyId = 2;
        A.CallTo(() => _applicationRepository.GetApplicationsForAdministrator(vacancyId))
            .Returns(new List<ApplicationDTO>());

        // Act
        var result = _reviewSubmittedApplicationsUseCase.GetInterviewApplications(vacancyId);

        // Assert
        Assert.Empty(result);
        A.CallTo(() => _applicationRepository.GetApplicationsForAdministrator(vacancyId))
            .MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void RejectInterviewApplication_ValidId_ChangesStatusToRejected()
    {
        // Arrange
        int applicationId = 10;
        A.CallTo(() => _applicationRepository.ChangeApplicationStatus(StatusEnum.REJECTED, applicationId))
            .DoesNothing();

        // Act
        var ex = Record.Exception(() => _reviewSubmittedApplicationsUseCase.RejectInterviewApplicaiton(applicationId));

        // Assert
        Assert.Null(ex);
        A.CallTo(() => _applicationRepository.ChangeApplicationStatus(StatusEnum.REJECTED, applicationId))
            .MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void GetDetailInterviewApplication_ValidId_ReturnsDetails()
    {
        // Arrange
        int applicationId = 20;
        var expectedDetail = new ApplicationDetailDTO
        {
            Id = applicationId,
            ApplicantName = "Juan Pérez",
            StatusId = 1
        };

        A.CallTo(() => _applicationRepository.GetApplicationDetails(applicationId))
            .Returns(expectedDetail);

        // Act
        var result = _reviewSubmittedApplicationsUseCase.GetDetailInterviewApplication(applicationId);

        // Assert
        Assert.Equal(expectedDetail, result);
        A.CallTo(() => _applicationRepository.GetApplicationDetails(applicationId))
            .MustHaveHappenedOnceExactly();
    }
}