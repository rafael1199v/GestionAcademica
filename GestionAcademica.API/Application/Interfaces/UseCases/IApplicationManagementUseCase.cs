using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.Interfaces.UseCases
{
    public interface IApplicationManagementUseCase
    {
        void CreateApplication(ApplicationDTO application);
        void UpdateApplication(ApplicationDTO application);
        ApplicationDTO GetApplicationById(int id);
        List<ApplicationDTO> GetApplicationsByVacancyId(int vacancyId);
        List<ApplicationDTO> GetApplicationsByApplicantId(int applicantId);
        List<ApplicationDTO> GetApplicationsByStatusId(int statusId);
        List<ApplicationDTO> GetApplicationsByOwnerId(int adminId);
    }
}