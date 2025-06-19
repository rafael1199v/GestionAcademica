using GestionAcademica.API.Domain.Entities;

namespace GestionAcademica.API.Infrastructure.Mappers;

public class ApplicationMapper
{
    public static Infrastructure.Persistence.Models.Application MapApplicationEntitytoApplicationModel(ApplicationEntity application)
    {
        return new Infrastructure.Persistence.Models.Application
        {
            Id = application.Id,
            ApplicantId = application.ApplicantId,
            StatusId = application.StatusId,
            VacancyId = application.VacancyId
        };
    }
}