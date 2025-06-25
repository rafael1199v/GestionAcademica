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
        if (applicationId <= 0)
            throw new ArgumentException("Se tiene que contar con una postulación para poder aceptar a un postulante");
        
        _applicationRepository.ChangeApplicationStatus(StatusEnum.ACCEPTED, applicationId);
        _applicationRepository.FinishOtherApplications(applicationId);
        
        var applicant = _applicationRepository.GetApplicantByApplication(applicationId);

        return applicant;
    }
}