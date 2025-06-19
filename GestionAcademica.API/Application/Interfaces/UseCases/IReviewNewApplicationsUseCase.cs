using GestionAcademica.API.Application.DTOs.Application;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IReviewNewApplicationsUseCase
{
    List<ApplicationDTO> GetNewApplications();
    ApplicationDetailDTO GetDetailNewApplication(int applicationId);

    void RejectApplication(int applicationId);

    void AdvanceApplicationToInterview(int applicationId);
}