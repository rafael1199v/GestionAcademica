using ApplicationModel = GestionAcademica.API.Infrastructure.Persistence.Models.Application;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.API.Infrastructure.Persistence.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly GestionAcademicaContext _context;
        public ApplicationRepository(GestionAcademicaContext context)
        {
            _context = context;
        }
        public void Create(ApplicationModel application)
        {
            if (application == null)
                throw new ArgumentNullException(nameof(application), "La solicitud no puede ser nula.");

            _context.Applications.Add(application);
            _context.SaveChanges();
        }

        public List<ApplicationModel> GetByApplicant(int applicantId)
        {
            if (applicantId <= 0)
                throw new ArgumentException("ID inválido", nameof(applicantId));

            return _context.Applications
                .Where(a => a.ApplicantId == applicantId)
                .Include(a => a.Vacancy)
                .ToList();
        }

        public ApplicationModel GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido", nameof(id));

            var application = _context.Applications
                .Include(a => a.Vacancy)
                .FirstOrDefault(a => a.Id == id)
                ?? throw new Exception("Solicitud no encontrada");
            return application;
        }

        public List<ApplicationModel> GetByOwner(int adminId)
        {
            if (adminId <= 0)
                throw new ArgumentException("ID inválido", nameof(adminId));
            return _context.Applications
                .Where(a => a.Vacancy.AdminId == adminId)
                .Include(a => a.Vacancy)
                .ToList();
        }

        public List<ApplicationModel> GetByStatus(int statusId)
        {
            return _context.Applications
                .Where(a => a.StatusId == statusId)
                .Include(a => a.Vacancy)
                .ToList();
        }

        public List<ApplicationModel> GetByVacancy(int vacancyId)
        {
            return _context.Applications
                .Where(a => a.VacancyId == vacancyId)
                .Include(a => a.Vacancy)
                .ToList();
        }

        public void Update(ApplicationModel application)
        {
            if (application == null || application.Id <= 0)
                throw new ArgumentNullException(nameof(application), "Solicitud inválida.");

            var existingApplication = _context.Applications
                .FirstOrDefault(a => a.Id == application.Id)
                ?? throw new Exception("Solicitud no encontrada");
            existingApplication.StatusId = application.StatusId;

            _context.Entry(existingApplication).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}