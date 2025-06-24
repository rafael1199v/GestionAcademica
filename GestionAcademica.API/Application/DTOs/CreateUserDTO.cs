using System.ComponentModel.DataAnnotations;

namespace GestionAcademica.API.Application.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string BirthDate { get; set; } = null!;
    }
}
