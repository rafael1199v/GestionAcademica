using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Domain.Enums;

namespace GestionAcademica.API.Application.UseCases.AdministratorUseCases;

public class ReviewSubmittedApplicationsUseCase : IReviewSubmittedApplicationsUseCase
{
    
    private readonly IApplicationRepository _applicationRepository;

    public ReviewSubmittedApplicationsUseCase(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }
    
    public List<ApplicationDTO> GetInterviewApplications(int vacancyId)
    {
        var applications = _applicationRepository.GetApplicationsForAdministrator(vacancyId);

        return applications;
    }

    public void RejectInterviewApplicaiton(int applicationId)
    {
        _applicationRepository.ChangeApplicationStatus(StatusEnum.REJECTED, applicationId);
    }

    public ApplicationDetailDTO GetDetailInterviewApplication(int applicationId)
    {
        var applicationDetail = _applicationRepository.GetApplicationDetails(applicationId);
        
        return applicationDetail;
    }
}