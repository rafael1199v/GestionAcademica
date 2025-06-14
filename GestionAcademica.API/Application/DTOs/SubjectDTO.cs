namespace GestionAcademica.API.Application.DTOs;
public class SubjectDTO
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public int Credits { get; set; }
    
    public int ProfessorId { get; set; }
    
    public string ProfessorName { get; set; } = null!;
}