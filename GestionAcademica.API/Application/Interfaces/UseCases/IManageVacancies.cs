using GestionAcademica.API.Application.DTOs.Vacancy;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IManageVacancies
{
    List<VacancyDTO> GetVacancies(int userId);
    void UpdateVacancy(UpdateVacancyDTO vacancyDto);
    void DeleteVacancy(int vacancyId);
    UpdateVacancyDTO GetVacancyToUpdate(int vacancyId);
}