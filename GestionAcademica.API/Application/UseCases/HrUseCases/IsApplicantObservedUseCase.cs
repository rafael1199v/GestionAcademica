using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Domain.Enums;

namespace GestionAcademica.API.Application.UseCases.HrUseCases;

public class IsApplicantObservedUseCase : IIsApplicantObservedUseCase
{
    private readonly IApplicationRepository _applicationRepository;

    public IsApplicantObservedUseCase(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }
    
    public bool IsObserved(int applicantId)
    {
        return _applicationRepository.IsObserved(applicantId);
    }
}