using GestionAcademica.API.Application.DTOs.Applicant;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using ApplicationModel = GestionAcademica.API.Infrastructure.Persistence.Models.Application;
// Con esto puedes suprimir líneas largas por la declaración de un objeto Application

namespace GestionAcademica.API.Application.Interfaces.Repositories;

public interface IApplicationRepository
{
    int Add(ApplicationEntity application);
    List<ApplicationDTO> GetApplicationsForApplicant(int applicantId); 
    ApplicationDetailDTO GetApplicationDetails(int applicationId);
    List<ApplicationDTO> GetApplicationsForHr();
    List<ApplicationDTO> GetApplicationsForAdministrator(int vacancyId);
    void ChangeApplicationStatus(StatusEnum newStatus, int applicationId);
    ApplicantDTO GetApplicantByApplication(int applicationId);
    void FinishOtherApplications(int applicationAcceptedId);

    bool ApplicantWasRejected(int applicantId);
}