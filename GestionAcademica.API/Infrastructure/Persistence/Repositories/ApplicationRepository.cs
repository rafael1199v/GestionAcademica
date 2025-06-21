using GestionAcademica.API.Application.DTOs.Applicant;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.DTOs.File;
using GestionAcademica.API.Application.DTOs.User;
using GestionAcademica.API.Application.DTOs.Vacancy;
using ApplicationModel = GestionAcademica.API.Infrastructure.Persistence.Models.Application;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
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
                    StatusId = application.StatusId,
                    VacancyName = application.Vacancy.Name,
                    VacancyDescription = application.Vacancy.Description,
                    VacancyCareerName = application.Vacancy.Career.Name,
                    ApplicantName = application.Applicant.User.Name + " " + application.Applicant.User.LastName,
                    AdministratorName = application.Vacancy.Admin.User.Name + " " + application.Vacancy.Admin.User.LastName,
                    VacancySubjectName = application.Vacancy.Subject.Name
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
                    StatusId = _application.StatusId,
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

        public List<ApplicationDTO> GetApplicationsForHr()
        {
            var applications = _context.Applications.Where(application => application.Status.Id == (int)StatusEnum.UNDER_REVIEW 
            && application.Vacancy.StartTime <= DateTime.Now && DateTime.Now < application.Vacancy.EndTime)
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
                    VacancySubjectName = application.Vacancy.Subject.Name
                }).ToList();
            
            return applications;
        }

        public List<ApplicationDTO> GetApplicationsForAdministrator(int vacancyId)
        {
            var applications = _context.Applications.Where(application => application.VacancyId == vacancyId)
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
                    AdministratorName = application.Applicant.User.Name + " " + application.Applicant.User.LastName,
                    VacancySubjectName = application.Vacancy.Subject.Name
                })
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
        {
            var applicant = _context.Applications.Where(application => application.Id == applicationId)
                .Select(application => new ApplicantDTO
                {
                    Id = application.Applicant.Id,
                    UserId = application.Applicant.User.Id,
                    User = new UserDTO
                    {
                        Id =  application.Applicant.User.Id,
                        Name = application.Applicant.User.Name,
                        LastName = application.Applicant.User.LastName,
                        Address = application.Applicant.User.Address,
                        PersonalEmail = application.Applicant.User.PersonalEmail,
                        InstitutionalEmail = application.Applicant.User.InstitutionalEmail,
                        PhoneNumber = application.Applicant.User.PhoneNumber,
                        BirthDate = application.Applicant.User.BirthDate.ToString("O"),
                        Status = application.Applicant.User.Status,
                        RoleId = application.Applicant.User.RoleId,
                    }
                }).FirstOrDefault();

            if (applicant is null)
                throw new Exception("El aplicante no pudo ser encontrado");
            
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