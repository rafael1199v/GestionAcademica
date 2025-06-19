using GestionAcademica.API.Application.DTOs.Application;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IViewOwnApplications
{
    List<ApplicationDTO> GetOwnApplications(int applicantId);
    ApplicationDetailDTO GetApplicationDetail(int applicationId);
}