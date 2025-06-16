using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Infrastructure.Persistance.Context;
using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Infrastructure.Persistance.Repositories;

public class VacancyRepository : IVacancyRepository
{
    private readonly GestionAcademicaContext _context;

    public VacancyRepository(GestionAcademicaContext context)
    {
        _context = context;
    }
    
    public void Add(Vacancy vacancy)
    {
        _context.Vacancies.Add(vacancy);
        _context.SaveChanges();
    }
}