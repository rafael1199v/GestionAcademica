using GestionAcademica.API.Domain.Exceptions;

namespace GestionAcademica.API.Domain.Entities;

public class ApplicationEntity
{
    public int Id { get; set; }

    public int VacancyId { get; set; }

    public int ApplicantId { get; set; }

    public int StatusId { get; set; }
    
    public static ApplicationEntity CreateApplication(int vacancyId, int applicantId, int statusId)
    {
        if (vacancyId <= 0)
            throw new DomainException("Se necesita una vacante para poder postular");

        if (applicantId <= 0)
            throw new DomainException("Se necesita una vacante para poder postular");

        if (statusId <= 0)
            throw new DomainException("Se requiere un estado inicial para la postulacion");
        
        return new ApplicationEntity
        {
            Id = 0,
            VacancyId = vacancyId,
            ApplicantId = applicantId,
            StatusId = statusId
        };
    }
}