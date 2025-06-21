namespace GestionAcademica.API.Application.DTOs.User;

public class UserDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PersonalEmail { get; set; } = null!;
    public string InstitutionalEmail { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string BirthDate { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int RoleId { get; set; }
}