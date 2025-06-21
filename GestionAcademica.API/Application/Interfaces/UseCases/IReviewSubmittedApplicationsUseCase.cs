using GestionAcademica.API.Application.DTOs.Application;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IReviewSubmittedApplicationsUseCase
{
    List<ApplicationDTO> GetInterviewApplications(int vacancyId);

    void RejectInterviewApplicaiton(int applicationId);

    ApplicationDetailDTO GetDetailInterviewApplication(int applicationId);

}