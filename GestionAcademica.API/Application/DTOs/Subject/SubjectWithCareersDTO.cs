using GestionAcademica.API.Application.DTOs.Career;

namespace GestionAcademica.API.Application.DTOs.Subject;

public class SubjectWithCareersDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Credits { get; set; }
    
    public List<CareerDTO> Careers { get; set; }
    
}