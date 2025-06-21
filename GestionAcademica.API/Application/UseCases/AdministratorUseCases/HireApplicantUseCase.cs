using GestionAcademica.API.Application.DTOs.Applicant;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Domain.Enums;

namespace GestionAcademica.API.Application.UseCases.AdministratorUseCases;

public class HireApplicantUseCase : IHireApplicantUseCase
{
    
    private readonly IApplicationRepository _applicationRepository;

    public HireApplicantUseCase(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }
    
    public ApplicantDTO HireApplicantByApplication(int applicationId)
    {
        _applicationRepository.ChangeApplicationStatus(StatusEnum.ACCEPTED, applicationId);
        _applicationRepository.FinishOtherApplications(applicationId);
        
        var applicant = _applicationRepository.GetApplicantByApplication(applicationId);

        return applicant;
    }
}