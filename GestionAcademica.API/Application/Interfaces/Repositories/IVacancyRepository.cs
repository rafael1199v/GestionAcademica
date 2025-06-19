using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories;

public interface IVacancyRepository
{
    void Add(Vacancy vacancy);
    List<Vacancy> GetByCreator(int adminId);
    Vacancy GetById(int vacancyId);
    void Update(Vacancy vacancy);
    void Delete(int vacancyId);
    List<Vacancy> GetForApplicants();
}