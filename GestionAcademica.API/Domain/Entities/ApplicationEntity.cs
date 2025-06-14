namespace GestionAcademica.API.Domain.Entities;

public class ApplicationEntity
{
    public int Id { get; set; }

    public int VacancyId { get; set; }

    public int ApplicantId { get; set; }

    public int StatusId { get; set; }
}