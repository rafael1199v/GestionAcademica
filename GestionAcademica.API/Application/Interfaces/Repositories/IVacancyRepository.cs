using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories;

public interface IVacancyRepository
{
    void Add(VacancyEntity entity);
    List<VacancyDTO> GetByCreator(int adminId);
    VacancyEntity GetById(int vacancyId);
    void Update(VacancyEntity entity);
    void Delete(int vacancyId);
    List<VacancyDTO> GetForApplicants(int applicantId);
    int GetAdminId(int vacancyId);
}