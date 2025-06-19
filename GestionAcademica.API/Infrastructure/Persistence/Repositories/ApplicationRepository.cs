using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.DTOs.File;
using ApplicationModel = GestionAcademica.API.Infrastructure.Persistence.Models.Application;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Domain.Entities;
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
        // public void Create(ApplicationModel application)
        // {
        //     if (application == null)
        //         throw new ArgumentNullException(nameof(application), "La solicitud no puede ser nula.");
        //
        //     _context.Applications.Add(application);
        //     _context.SaveChanges();
        // }
        //
        // public List<ApplicationModel> GetByApplicant(int applicantId)
        // {
        //     if (applicantId <= 0)
        //         throw new ArgumentException("ID inválido", nameof(applicantId));
        //
        //     return _context.Applications
        //         .Where(a => a.ApplicantId == applicantId)
        //         .Include(a => a.Vacancy)
        //         .Include(b => b.Status)
        //         .Include(c => c.Applicant.User)
        //         .Include(d => d.Vacancy.Admin.User)
        //         .ToList();
        // }
        //
        // public ApplicationModel GetById(int id)
        // {
        //     if (id <= 0)
        //         throw new ArgumentException("ID inválido", nameof(id));
        //
        //     var application = _context.Applications
        //         .Include(a => a.Vacancy)
        //         .Include(b => b.Status)
        //         .Include(c => c.Applicant.User)
        //         .Include(d => d.Vacancy.Admin.User)
        //         .FirstOrDefault(a => a.Id == id)
        //         ?? throw new Exception("Solicitud no encontrada");
        //     return application;
        // }
        //
        // public List<ApplicationModel> GetByOwner(int adminId)
        // {
        //     if (adminId <= 0)
        //         throw new ArgumentException("ID inválido", nameof(adminId));
        //     return _context.Applications
        //         .Where(a => a.Vacancy.AdminId == adminId /*&& a.StatusId == 2*/)
        //         // TODO: Incluir una alternativa que muestre todas las postulaciones sin importar el estado
        //         .Include(a => a.Vacancy)
        //         .Include(b => b.Status)
        //         .Include(c => c.Applicant.User)
        //         .Include(d => d.Vacancy.Admin.User)
        //         .ToList();
        // }
        //
        // public List<ApplicationModel> GetByStatus(int statusId)
        // {
        //     return _context.Applications
        //         .Where(a => a.StatusId == statusId)
        //         .Include(a => a.Vacancy)
        //         .Include(b => b.Status)
        //         .Include(c => c.Applicant.User)
        //         .Include(d => d.Vacancy.Admin.User)
        //         .ToList();
        // }
        //
        // public List<ApplicationModel> GetByVacancy(int vacancyId)
        // {
        //     return _context.Applications
        //         .Where(a => a.VacancyId == vacancyId)
        //         .Include(a => a.Vacancy)
        //         .Include(b => b.Status)
        //         .Include(c => c.Applicant.User)
        //         .Include(d => d.Vacancy.Admin.User)
        //         .ToList();
        // }
        //
        // public void Update(ApplicationModel application)
        // {
        //     if (application == null || application.Id <= 0)
        //         throw new ArgumentNullException(nameof(application), "Solicitud inválida.");
        //
        //     var existingApplication = _context.Applications
        //         .FirstOrDefault(a => a.Id == application.Id)
        //         ?? throw new Exception("Solicitud no encontrada");
        //     existingApplication.StatusId = application.StatusId;
        //
        //     _context.Entry(existingApplication).State = EntityState.Modified;
        //     _context.SaveChanges();
        // }

        public int Add(ApplicationEntity application)
        {
            var applicationModel = ToModel(application);
            
            _context.Applications.Add(applicationModel);
            _context.SaveChanges();
            
            return applicationModel.Id;
        }

        public List<ApplicationDTO> GetApplicationsForApplicant(int applicantId)
        {
            var applications =  _context.Applications.Where(application => application.ApplicantId == applicantId)
                .Select(application => new ApplicationDTO
                {
                    Id = application.Id,
                    VacancyId = application.VacancyId,
                    ApplicantId = application.ApplicantId,
                    StatusId = application.Status.Id,
                    VacancyName = application.Vacancy.Name,
                    VacancyDescription = application.Vacancy.Description,
                    VacancyCareerName = application.Vacancy.Career.Name,
                    ApplicantName = application.Applicant.User.Name + " " + application.Applicant.User.LastName,
                    AdministratorName = application.Vacancy.Admin.User.Name + " " + application.Vacancy.Admin.User.LastName,
                }).ToList();

            return applications;
        }

        public ApplicationDetailDTO GetApplicationDetails(int applicationId)
        {
            var application = _context.Applications.Where(application => application.Id == applicationId)
                .Select(_application => new ApplicationDetailDTO
                {
                    Id = _application.Id,
                    VacancyId = _application.VacancyId,
                    ApplicantId = _application.ApplicantId,
                    StatusId = _application.Status.Id,
                    VacancyName = _application.Vacancy.Name,
                    VacancyDescription = _application.Vacancy.Description,
                    VacancyCareerName = _application.Vacancy.Career.Name,
                    ApplicantName = _application.Applicant.User.Name + " " + _application.Applicant.User.LastName,
                    AdministratorName = _application.Vacancy.Admin.User.Name + " " +
                                        _application.Vacancy.Admin.User.LastName,
                    Files = _application.Files.Select(file => new FileDTO
                    {
                        Id = file.Id,
                        Name = file.Filename,
                        Description = file.FileDescription,
                        Extension = file.FileExtension
                    }).ToList()
                })
                .FirstOrDefault();
            
            
            if(application is null)
                throw new Exception("La postulacion no se encontro el sistema");
            
            return application;
        }

        private ApplicationModel ToModel(ApplicationEntity application)
        {
            return new ApplicationModel
            {
                Id = application.Id,
                ApplicantId = application.ApplicantId,
                StatusId = application.StatusId,
                VacancyId = application.VacancyId,
            };
        }
    }
}