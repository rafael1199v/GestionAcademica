using GestionAcademica.API.Application.DTOs.User;

namespace GestionAcademica.API.Application.DTOs.Applicant;

public class ApplicantDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserDTO? User { get; set; }
}