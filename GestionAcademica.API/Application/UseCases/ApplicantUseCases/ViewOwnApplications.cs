using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;

namespace GestionAcademica.API.Application.UseCases.ApplicantUseCases;

public class ViewOwnApplications : IViewOwnApplications
{
    private readonly IApplicationRepository _applicationRepository;

    public ViewOwnApplications(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }
    
    public List<ApplicationDTO> GetOwnApplications(int applicantId)
    {
        return _applicationRepository.GetApplicationsForApplicant(applicantId);
    }

    public ApplicationDetailDTO GetApplicationDetail(int applicationId)
    {
        return _applicationRepository.GetApplicationDetails(applicationId);
    }
}