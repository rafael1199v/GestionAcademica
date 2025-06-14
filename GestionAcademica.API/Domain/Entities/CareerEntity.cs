namespace GestionAcademica.API.Domain.Entities;

public class CareerEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? AdministratorId { get; set; }
}