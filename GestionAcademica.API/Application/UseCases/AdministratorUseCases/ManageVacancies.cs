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

        int adminId = _vacancyRepository.GetAdminId(vacancyDto.Id);
        VacancyEntity entity = VacancyEntity.CreateVacancy(vacancyDto.Name, vacancyDto.Description, startTime, endTime, vacancyDto.SubjectId, vacancyDto.CareerId, adminId);

        entity.SetIdentifier(vacancyDto.Id);
        
        _vacancyRepository.Update(entity);
    }

    public void DeleteVacancy(int vacancyId)
    {
        _vacancyRepository.Delete(vacancyId);
    }
    
    public UpdateVacancyDTO GetVacancyToUpdate(int vacancyId)
    {
        if (vacancyId <= 0)
            throw new ArgumentException("Se necesita una vacante valida para actualizar");
        
        var vacancy = _vacancyRepository.GetById(vacancyId);

        return EntityToUpdateVacancyDto(vacancy);
    }

    public UpdateVacancyDTO EntityToUpdateVacancyDto(VacancyEntity vacancy)
    {
        return new UpdateVacancyDTO
        {
            Id = vacancy.Id,
            Name = vacancy.Name,
            Description = vacancy.Description,
            StartTime = vacancy.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
            EndTime = vacancy.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
            CareerId = vacancy.CareerId,
            SubjectId = vacancy.SubjectId
        };
    }
    
    
    
}