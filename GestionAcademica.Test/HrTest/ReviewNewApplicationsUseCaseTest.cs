using FakeItEasy;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.UseCases.HrUseCases;
using GestionAcademica.API.Domain.Enums;

namespace GestionAcademica.Test.HrTest;

public class ReviewNewApplicationsUseCaseTest
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly ReviewNewApplicationsUseCase _reviewNewApplicationsUseCase;

    public ReviewNewApplicationsUseCaseTest()
    {
        _applicationRepository = A.Fake<IApplicationRepository>();
        _reviewNewApplicationsUseCase = new ReviewNewApplicationsUseCase(_applicationRepository);
    }

    [Fact]
    public void GetNewApplications_ReturnsResults()
    {
        // Arrange
        var expectedApplications = new List<ApplicationDTO>
        {
            new ApplicationDTO { Id = 101 },
            new ApplicationDTO { Id = 102 }
        };

        A.CallTo(() => _applicationRepository.GetApplicationsForHr())
            .Returns(expectedApplications);

        // Act
        var result = _reviewNewApplicationsUseCase.GetNewApplications();

        // Assert
        Assert.Equal(expectedApplications, result);
        A.CallTo(() => _applicationRepository.GetApplicationsForHr())
            .MustHaveHappenedOnceExactly();
    }
    [Fact]
    public void GetNewApplications_ReturnsNothing()
    {
        // Arrange
        A.CallTo(() => _applicationRepository.GetApplicationsForHr())
            .Returns(new List<ApplicationDTO>());

        // Act
        var result = _reviewNewApplicationsUseCase.GetNewApplications();

        // Assert
        Assert.Empty(result);
        A.CallTo(() => _applicationRepository.GetApplicationsForHr())
            .MustHaveHappenedOnceExactly();
    }
    [Fact]
    public void GetDetailNewApplication_ValidId_ReturnsDetails()
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
        var result = _reviewNewApplicationsUseCase.GetDetailNewApplication(applicationId);

        // Assert
        Assert.Equal(expectedDetail, result);
        A.CallTo(() => _applicationRepository.GetApplicationDetails(applicationId))
            .MustHaveHappenedOnceExactly();
    }
    [Fact]
    public void AdvanceApplicationToInterview_ValidId_ChangesStatusToInterview()
    {
        // Arrange
        int applicationId = 10;
        A.CallTo(() => _applicationRepository.ChangeApplicationStatus(StatusEnum.INTERVIEW, applicationId))
            .DoesNothing();

        // Act
        var ex = Record.Exception(() => _reviewNewApplicationsUseCase.AdvanceApplicationToInterview(applicationId));

        // Assert
        Assert.Null(ex);
        A.CallTo(() => _applicationRepository.ChangeApplicationStatus(StatusEnum.INTERVIEW, applicationId))
            .MustHaveHappenedOnceExactly();
    }
}