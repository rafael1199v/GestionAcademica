using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Domain.Enums;

namespace GestionAcademica.API.Application.UseCases.HrUseCases;

public class ReviewNewApplicationsUseCase : IReviewNewApplicationsUseCase
{
    
    private readonly IApplicationRepository _applicationRepository;

    public ReviewNewApplicationsUseCase(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }
    
    public List<ApplicationDTO> GetNewApplications()
    {
        return _applicationRepository.GetApplicationsForHr();
    }

    public ApplicationDetailDTO GetDetailNewApplication(int applicationId)
    {
        return _applicationRepository.GetApplicationDetails(applicationId);
    }

    public void RejectApplication(int applicationId)
    {
        _applicationRepository.ChangeApplicationStatus(StatusEnum.REJECTED, applicationId);
    }

    public void AdvanceApplicationToInterview(int applicationId)
    {
        _applicationRepository.ChangeApplicationStatus(StatusEnum.INTERVIEW, applicationId);
    }
}