using GestionAcademica.API.Application.DTOs.Applicant;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistence.Context;
using GestionAcademica.API.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using GestionAcademica.API.Infrastructure.Mappers;

namespace GestionAcademica.API.Infrastructure.Persistence.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly GestionAcademicaContext _context;
        public ApplicationRepository(GestionAcademicaContext context)
        {
            _context = context;
        }

        public int Add(ApplicationEntity application)
        {
            var applicationModel = ApplicationMapper.EntityToModel(application);
            
            _context.Applications.Add(applicationModel);
            _context.SaveChanges();
            
            return applicationModel.Id;
        }

        public List<ApplicationDTO> GetApplicationsForApplicant(int applicantId)
        {
             List<ApplicationDTO> applications =  _context.Applications.Where(application => application.ApplicantId == applicantId)
                 .Include(application => application.Vacancy)
                 .ThenInclude(vacancy => vacancy.Career)
                 
                 .Include(application => application.Applicant)
                 .ThenInclude(applicant => applicant.User)
                 
                 .Include(application => application.Vacancy)
                 .ThenInclude(vacancy => vacancy.Admin)
                 .ThenInclude(admin => admin.User)
                 
                 .Include(application => application.Vacancy)
                 .ThenInclude(vacancy => vacancy.Subject)
                 
                 .Select(application => ApplicationMapper.ModelToDTO(application))
                 .ToList();
            
            return applications;
            
        }

        public ApplicationDetailDTO GetApplicationDetails(int applicationId)
        {
            ApplicationDetailDTO? application = _context.Applications.Where(application => application.Id == applicationId)
                .Include(application => application.Vacancy)
                .ThenInclude(vacancy => vacancy.Career)

                .Include(application => application.Applicant)
                .ThenInclude(applicant => applicant.User)

                .Include(application => application.Vacancy)
                .ThenInclude(vacancy => vacancy.Admin)
                .ThenInclude(admin => admin.User)

                .Include(application => application.Vacancy)
                .ThenInclude(vacancy => vacancy.Subject)
                
                .Include(application => application.Files)

                .Select(_application => ApplicationMapper.ApplicationModelToApplicationDetailDTO(_application))
                .FirstOrDefault()
                ?? throw new Exception("La postulacion no se encontro el sistema");

            return application;
        }

        public List<ApplicationDTO> GetApplicationsForHr()
        {
            var applications = _context.Applications.Where(application => application.Status.Id == (int)StatusEnum.UNDER_REVIEW
            && application.Vacancy.StartTime <= DateTime.Now && DateTime.Now < application.Vacancy.EndTime)
                .Include(application => application.Vacancy)
                .ThenInclude(vacancy => vacancy.Career)
                
                .Include(application => application.Applicant)
                .ThenInclude(applicant => applicant.User)
                
                .Include(application => application.Vacancy)
                .ThenInclude(vacancy => vacancy.Admin)
                .ThenInclude(admin => admin.User)
                
                .Include(application => application.Vacancy)
                .ThenInclude(vacancy => vacancy.Subject)
                
                .Select(application => ApplicationMapper.ModelToDTO(application))
                .ToList();
            
            return applications;
        }

        public List<ApplicationDTO> GetApplicationsForAdministrator(int vacancyId)
        {
            List<ApplicationDTO> applications = _context.Applications.Where(application => application.VacancyId == vacancyId)
                .Include(application => application.Vacancy)
                .ThenInclude(vacancy => vacancy.Career)
                
                .Include(application => application.Applicant)
                .ThenInclude(applicant => applicant.User)
                
                .Include(application => application.Vacancy)
                .ThenInclude(vacancy => vacancy.Admin)
                .ThenInclude(admin => admin.User)
                
                .Include(application => application.Vacancy)
                .ThenInclude(vacancy => vacancy.Subject)
                
                .Select(application => ApplicationMapper.ModelToDTO(application))
                .ToList();
            
            return applications;
        }

        public void ChangeApplicationStatus(StatusEnum newStatus, int applicationId)
        {
            var applicationModel = _context.Applications.FirstOrDefault(application => application.Id == applicationId);
            
            if(applicationModel is null)
                throw new Exception("No se encontro la postulacion");
            
            applicationModel.StatusId = (int)newStatus;

            _context.SaveChanges();
        }

        public ApplicantDTO GetApplicantByApplication(int applicationId)
        { // Este está bien aquí????
            ApplicantDTO applicant = _context.Applications.Where(application => application.Id == applicationId)
                                         
                 .Include(application => application.Applicant)
                 .ThenInclude(applicant => applicant.User)
                 
                .Select(_applicant => ApplicantMapper.ExtractApplicantData(_applicant))
                .FirstOrDefault()
                ?? throw new Exception("El aplicante no pudo ser encontrado");

            return applicant;
        }

        public void FinishOtherApplications(int applicationAcceptedId)
        {
            var applicationAccepted = _context.Applications.FirstOrDefault(application => application.Id == applicationAcceptedId);

            if (applicationAccepted is null)
                throw new Exception("La postulacion aceptada no pudo ser encontrada");

            var otherApplications = _context.Applications
                .Where(application => application.VacancyId == applicationAccepted.VacancyId 
                                      && application.Id != applicationAcceptedId 
                                      && application.StatusId != (int)StatusEnum.REJECTED)
                .ToList();

            foreach (var application in otherApplications)
            {
                application.StatusId = (int)StatusEnum.CLOSED;
            }

            _context.SaveChanges();
        }
    }
}