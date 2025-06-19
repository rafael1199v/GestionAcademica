using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Domain.Entities;
using ApplicationModel = GestionAcademica.API.Infrastructure.Persistence.Models.Application;
// Con esto puedes suprimir líneas largas por la declaración de un objeto Application

namespace GestionAcademica.API.Application.Interfaces.Repositories;

public interface IApplicationRepository
{
    // void Create(ApplicationModel application);
    // ApplicationModel GetById(int id);
    // List<ApplicationModel> GetByVacancy(int vacancyId);
    // List<ApplicationModel> GetByApplicant(int applicantId);
    // List<ApplicationModel> GetByOwner(int adminId);
    // List<ApplicationModel> GetByStatus(int statusId);
    // void Update(ApplicationModel application);
    int Add(ApplicationEntity application);
    List<ApplicationDTO> GetApplicationsForApplicant(int applicantId); 
    ApplicationDetailDTO GetApplicationDetails(int applicationId);
    List<ApplicationDTO> GetApplicationsForHr();
    void RejectApplication(int applicationId);
    void AdvanceToInterview(int applicationId);
}