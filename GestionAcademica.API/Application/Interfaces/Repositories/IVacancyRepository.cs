using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Application.Interfaces.Repositories;

public interface IVacancyRepository
{
    void Add(Vacancy vacancy);
    List<Vacancy> GetByCreator(int adminId);
}