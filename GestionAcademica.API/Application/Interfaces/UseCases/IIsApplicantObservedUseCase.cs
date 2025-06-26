using GestionAcademica.API.Application.DTOs.Application;

namespace GestionAcademica.API.Application.Interfaces.UseCases;

public interface IIsApplicantObservedUseCase
{
    bool IsObserved(int applicantId);
}