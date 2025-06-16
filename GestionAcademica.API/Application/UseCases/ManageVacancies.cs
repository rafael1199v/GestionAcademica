using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Mappers;
using GestionAcademica.API.Infrastructure.Persistance.Models;

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
        throw new NotImplementedException();
    }

    public void DeleteVacancy(int vacancyId)
    {
        throw new NotImplementedException();
    }

    public DetailVacancyDTO GetVacancy(int vacancyId)
    {
        throw new NotImplementedException();
    }
}