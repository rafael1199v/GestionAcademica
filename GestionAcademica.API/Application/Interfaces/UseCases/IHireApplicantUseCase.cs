using GestionAcademica.API.Application.DTOs.Applicant;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IHireApplicantUseCase
{
    ApplicantDTO HireApplicantByApplication(int applicationId);   
}