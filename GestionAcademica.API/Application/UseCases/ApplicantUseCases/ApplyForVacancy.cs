using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;

namespace GestionAcademica.API.Application.UseCases.ApplicantUseCases;

public class ApplyForVacancy : IApplyForVacancy
{
    
    private readonly IVacancyRepository _vacancyRepository;
    private readonly IUploadFilesUseCase _uploadFilesUseCase;
    private readonly IApplicationRepository _applicationRepository;
    private readonly IIsApplicantObservedUseCase _isApplicantObservedUseCase;

    public ApplyForVacancy(IVacancyRepository vacancyRepository, IUploadFilesUseCase uploadFilesUseCase, IApplicationRepository applicationRepository, IIsApplicantObservedUseCase isApplicantObservedUseCase)
    {
        _vacancyRepository = vacancyRepository;
        _uploadFilesUseCase = uploadFilesUseCase;
        _applicationRepository = applicationRepository;
        _isApplicantObservedUseCase = isApplicantObservedUseCase;
    }
    
    public List<VacancyDTO> GetAvailableVacancies(int applicantId)
    {
        var vacancies = _vacancyRepository.GetForApplicants(applicantId);

        return vacancies;
    }

    public void Apply(CreateApplicationDTO dto)
    {
        if(dto.Files is null)
            throw new ArgumentException("Se necesita subir por lo menos un archivo");

        if (dto.Files.Count > 6)
            throw new ArgumentException("Se pueden subir maximo 6 archivos para una postulacion");

        if (_isApplicantObservedUseCase.IsObserved(dto.ApplicantId))
        {
            dto.StatusId = (int)StatusEnum.OBSERVED;
        }
        
        ApplicationEntity applicationEntity = ApplicationEntity.CreateApplication(dto.VacancyId, dto.ApplicantId, dto.StatusId);
      
        int applicationId = _applicationRepository.Add(applicationEntity);
        
        _uploadFilesUseCase.Uploadfiles(dto.Files, applicationId);
    }
}