namespace GestionAcademica.API.Infrastructure.Persistance.Models;

public partial class Hr
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
