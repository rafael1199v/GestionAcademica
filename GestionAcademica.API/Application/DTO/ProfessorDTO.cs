using System.ComponentModel.DataAnnotations;

namespace GestionAcademica.API.Application.DTO
{
    public class ProfessorDTO
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } = null!;

        public string? MiddleName { get; set; }

        [Required]

        public string LastName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string BirthDate { get; set; } = null!;

        public int RoleId { get; set; }

        public int UserId { get; set; }
    }
}
