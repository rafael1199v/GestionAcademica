using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories;

public interface IVacancyRepository
{
    void Add(Vacancy vacancy);
    List<VacancyDTO> GetByCreator(int adminId);
    Vacancy GetById(int vacancyId);
    void Update(Vacancy vacancy);
    void Delete(int vacancyId);
    List<VacancyDTO> GetForApplicants(int applicantId);
}