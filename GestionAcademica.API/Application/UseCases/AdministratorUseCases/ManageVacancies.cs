using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Mappers;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.UseCases.AdministratorUseCases;

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
        var administratorId =  _administratorRepository.GetIdByUserId(userId);
        List<VacancyDTO> vacanciesDTO = _vacancyRepository.GetByCreator(administratorId);
       
        return  vacanciesDTO;
    }

    public void UpdateVacancy(UpdateVacancyDTO vacancyDto)
    {
        if (!DateTime.TryParse(vacancyDto.EndTime, out DateTime endTime) || !DateTime.TryParse(vacancyDto.StartTime, out DateTime startTime))
            throw new ArgumentException("La fecha es invalida");
        
        Vacancy vacancy = _vacancyRepository.GetById(vacancyDto.Id);
        VacancyEntity entity = VacancyEntity.CreateVacancy(vacancyDto.Name, vacancyDto.Description, startTime, endTime, vacancyDto.SubjectId, vacancyDto.CareerId, vacancy.AdminId);

        vacancy = VacancyMapper.UpdateVacancy(vacancy, entity);
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
        if (vacancyId <= 0)
            throw new ArgumentException("Se necesita una vacante valida para actualizar");
        
        var vacancy = _vacancyRepository.GetById(vacancyId);

        return VacancyMapper.MapVacancyToUpdateVacancyDto(vacancy);
    }
}