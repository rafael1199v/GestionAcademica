using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Mappers;
using Microsoft.JSInterop.Infrastructure;

namespace GestionAcademica.API.Application.UseCases;

public class ApplyForVacancy : IApplyForVacancy
{
    
    private readonly IVacancyRepository _vacancyRepository;
    private readonly IUploadFilesUseCase _uploadFilesUseCase;
    private readonly IApplicationRepository _applicationRepository;
    
    public ApplyForVacancy(IVacancyRepository vacancyRepository, IUploadFilesUseCase uploadFilesUseCase, IApplicationRepository applicationRepository)
    {
        _vacancyRepository = vacancyRepository;
        _uploadFilesUseCase = uploadFilesUseCase;
        _applicationRepository = applicationRepository;
    }
    
    public List<VacancyDTO> GetAvailableVacancies()
    {
        var vacancies = _vacancyRepository.GetForApplicants()
                                                .Select(vacancy => VacancyMapper.MapVacancyModelToVacancyDto(vacancy))
                                                .ToList();

        return vacancies;
    }

    public void Apply(CreateApplicationDTO dto)
    {
        if(dto.Files is null)
            throw new ArgumentException("Se necesita subir por lo menos un archivo");

        if (dto.Files.Count > 6)
            throw new ArgumentException("Se pueden subir maximo 6 archivos para una postulacion"); 
        
        ApplicationEntity applicationEntity = ApplicationEntity.CreateApplication(dto.VacancyId, dto.ApplicantId, dto.StatusId);
      
        int applicationId = _applicationRepository.Add(applicationEntity);
        
        _uploadFilesUseCase.Uploadfiles(dto.Files, applicationId);
    }
}