using System.Diagnostics;
using GestionAcademica.API.Application.DTOs.Subject;
using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Mappers;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.UseCases;

public class CreateVacancyUseCase : ICreateVacancyUseCase
{
    private readonly IVacancyRepository _vacancyRepository;
    private readonly ISubjectRepository _subjectRepository;
    private readonly IAdministratorRepository _administratorRepository;

    public CreateVacancyUseCase(IVacancyRepository vacancyRepository, ISubjectRepository subjectRepository, IAdministratorRepository administratorRepository)
    {
        _vacancyRepository = vacancyRepository;
        _subjectRepository = subjectRepository;
        _administratorRepository = administratorRepository;
    }
    
    public void CreateVacancy(CreateVacancyDTO createVacancyDto)
    {
        if (!DateTime.TryParse(createVacancyDto.EndTime, out DateTime endTime) || !DateTime.TryParse(createVacancyDto.StartTime, out DateTime startTime))
            throw new ArgumentException("La fecha es invalida");


        var administrator = _administratorRepository.GetByUserId(createVacancyDto.UserId);
        
        VacancyEntity entity = VacancyEntity.CreateVacancy(createVacancyDto.Name, createVacancyDto.Description, startTime, endTime, createVacancyDto.SubjectId, createVacancyDto.CareerId,  administrator.Id);
        
        Vacancy model = new Vacancy
        {
            Name = entity.Name,
            Description = entity.Description,
            StartTime = entity.StartTime,
            EndTime = entity.EndTime,
            SubjectId = entity.SubjectId,
            CareerId = entity.CareerId,
            AdminId = entity.AdminId
        };
        
        _vacancyRepository.Add(model);
    }


    public List<SubjectWithCareersDTO> GetSubjectsWithCareers()
    {
        return _subjectRepository.GetWithCareers().Select(subject => SubjectMapper.MapToSubjectWithCareersDTO(subject)).ToList();
    }
    
}