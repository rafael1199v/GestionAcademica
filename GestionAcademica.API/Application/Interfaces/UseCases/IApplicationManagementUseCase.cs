using GestionAcademica.API.Infrastructure.Persistence.Models;
using ApplicationModel = GestionAcademica.API.Infrastructure.Persistence.Models.Application;

namespace GestionAcademica.API.Application.Interfaces.UseCases
{
    public interface IApplicationManagementUseCase
    {
        void CreateApplication(ApplicationModel application);
        void UpdateApplication(ApplicationModel application);
        ApplicationModel GetApplicationById(int id);
        List<ApplicationModel> GetApplicationsByVacancyId(int vacancyId);
        List<ApplicationModel> GetApplicationsByApplicantId(int applicantId);
        List<ApplicationModel> GetApplicationsByStatusId(int statusId);
        List<ApplicationModel> GetApplicationsByOwnerId(int adminId);
    }
}