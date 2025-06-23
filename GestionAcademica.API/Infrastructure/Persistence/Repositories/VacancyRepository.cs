using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Mappers;
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

    public List<VacancyDTO> GetByCreator(int adminId)
    {
        var vacancies = _context.Vacancies.Where(vacancy => vacancy.AdminId == adminId)
            .Include(vacancy => vacancy.Career)
            .Include(vacancy => vacancy.Subject)
            .Include(vacancy => vacancy.Applications)
            .ThenInclude(application => application.Status)
            .Select(vacancy => VacancyMapper.MapVacancyModelToVacancyDto(vacancy))
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

    public void Delete(int vacancyId)
    {
        var vacancy = this.GetById(vacancyId);
        _context.Vacancies.Remove(vacancy);
        _context.SaveChanges();
    }

    public List<VacancyDTO> GetForApplicants(int applicantId)
    {
        var vacancies = _context.Vacancies
            .Where(vacancy => !vacancy.Applications.Any(application => application.Status.Id == (int)StatusEnum.ACCEPTED) && (vacancy.EndTime > DateTime.Now && vacancy.StartTime <= DateTime.Now)
            && !vacancy.Applications.Any(application => application.ApplicantId == applicantId))
            .Include(vacancy => vacancy.Career)
            .Include(vacancy => vacancy.Subject)
            .Include(vacancy => vacancy.Admin)
            .Select(vacancy => VacancyMapper.MapVacancyModelToVacancyDto(vacancy))
            .ToList();
        
        
        return vacancies;
    }
}