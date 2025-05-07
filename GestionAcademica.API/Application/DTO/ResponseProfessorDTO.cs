namespace GestionAcademica.API.Application.DTO;

public class ResponseProfessorDTO
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string PersonalEmail { get; set; } = null!;
    
    public string InstitutionalEmail { get; set; } = null!;
    
    public string? Address { get; set; }
    
    public string? PhoneNumber { get; set; }

    public string BirthDate { get; set; } = null!;
    
    public int RolId { get; set; }
}