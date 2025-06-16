using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Infrastructure.Persistence.Repositories;

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

    public List<Vacancy> GetByCreator(int adminId)
    {
        var vacancies = _context.Vacancies.Where(vacancy => vacancy.AdminId == adminId)
            .Include(vacancy => vacancy.Career)
            .Include(vacancy => vacancy.Subject)
            .Include(vacancy => vacancy.Applications)
            .ThenInclude(application => application.Status)
            .ToList();
 
        return vacancies;
    }

    public Vacancy GetById(int vacancyId)
    {
        var vacancy = _context.Vacancies
            .Include(vacancy => vacancy.Admin)
            .Include(vacancy => vacancy.Career)
            .Include(vacancy => vacancy.Subject)
            .Include(vacancy => vacancy.Applications)
            .ThenInclude(application => application.Status)
            .FirstOrDefault(vacancy => vacancy.Id == vacancyId);

        if(vacancy == null)
            throw new Exception("La vacante no fue encontrada");
        
        return vacancy;
    }

    public void Update(Vacancy vacancy)
    {
        _context.Vacancies.Update(vacancy);
        _context.SaveChanges();
    }
}