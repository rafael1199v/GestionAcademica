using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.DTOs.Vacancy;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IApplyForVacancy
{
    List<VacancyDTO> GetAvailableVacancies(int applicantId);
    
    void Apply(CreateApplicationDTO dto);
}