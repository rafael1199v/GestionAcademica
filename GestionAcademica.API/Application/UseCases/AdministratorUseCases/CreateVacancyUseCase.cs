using GestionAcademica.API.Application.DTOs.Subject;
using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Mappers;

namespace GestionAcademica.API.Application.UseCases.AdministratorUseCases;

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

        int administratorId = _administratorRepository.GetIdByUserId(createVacancyDto.UserId);
        
        VacancyEntity entity = VacancyEntity.CreateVacancy(createVacancyDto.Name, createVacancyDto.Description, startTime, endTime, createVacancyDto.SubjectId, createVacancyDto.CareerId,  administratorId);
        
        _vacancyRepository.Add(VacancyMapper.EntityToModel(entity));
    }


    public List<SubjectWithCareersDTO> GetSubjectsWithCareers()
    {
        return _subjectRepository.GetWithCareers().Select(subject => SubjectMapper.MapToSubjectWithCareersDTO(subject)).ToList();
    }
    
}