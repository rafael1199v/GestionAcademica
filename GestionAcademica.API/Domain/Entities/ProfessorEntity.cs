namespace GestionAcademica.API.Domain.Entities;

public class ProfessorEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    
    public UserEntity? User { get; set; }
    
}