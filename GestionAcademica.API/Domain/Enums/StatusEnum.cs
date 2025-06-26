namespace GestionAcademica.API.Domain.Enums;

public enum StatusEnum
{
    UNDER_REVIEW = 1,
    INTERVIEW = 2,
    ACCEPTED = 3,
    REJECTED = 4,
    CLOSED = 5,
    OBSERVED = 1002 // La base de datos tuvo un bug con el IDENTITY(1,1)
    // OBSERVED_MEETING = 1003
}