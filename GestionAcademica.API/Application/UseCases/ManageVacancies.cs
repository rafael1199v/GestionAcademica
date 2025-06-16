using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Mappers;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.UseCases;

public class ManageVacancies : IManageVacancies
{
    private readonly IVacancyRepository _vacancyRepository;
    private readonly IAdministratorRepository _administratorRepository;

    public ManageVacancies(IVacancyRepository vacancyRepository, IAdministratorRepository administratorRepository)
    {
        _vacancyRepository = vacancyRepository;
        _administratorRepository = administratorRepository;
    }
    
    public List<VacancyDTO> GetVacancies(int userId)
    {
        var administrator =  _administratorRepository.GetByUserId(userId);
        List<Vacancy> vacancies = _vacancyRepository.GetByCreator(administrator.Id);
        List<VacancyDTO> vacanciesDTO = vacancies.Select(vacancy => VacancyMapper.MapVacancyModelToVacancyDto(vacancy)).ToList();
        
        return  vacanciesDTO;
    }

    public void UpdateVacancy(UpdateVacancyDTO vacancyDto)
    {
        if (!DateTime.TryParse(vacancyDto.EndTime, out DateTime endTime) || !DateTime.TryParse(vacancyDto.StartTime, out DateTime startTime))
            throw new ArgumentException("La fecha es invalida");
        
        var vacancy = _vacancyRepository.GetById(vacancyDto.Id);
        VacancyEntity entity = VacancyEntity.CreateVacancy(vacancyDto.Name, vacancyDto.Description, startTime, endTime, vacancyDto.SubjectId, vacancyDto.CareerId, vacancy.AdminId);
        
        vacancy.Name = entity.Name;
        vacancy.Description = entity.Description;
        vacancy.StartTime = entity.StartTime;
        vacancy.EndTime = entity.EndTime;
        vacancy.SubjectId = entity.SubjectId;
        vacancy.CareerId = entity.CareerId;
        
        _vacancyRepository.Update(vacancy);
    }

    public void DeleteVacancy(int vacancyId)
    {
        _vacancyRepository.Delete(vacancyId);
    }

    public DetailVacancyDTO GetVacancy(int vacancyId)
    {
        throw new NotImplementedException();
    }

    public UpdateVacancyDTO GetVacancyToUpdate(int vacancyId)
    {
        var vacancy = _vacancyRepository.GetById(vacancyId);

        return VacancyMapper.MapVacancyToUpdateVacancyDto(vacancy);
    }
}