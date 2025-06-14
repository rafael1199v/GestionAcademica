using System.ComponentModel.DataAnnotations;

namespace GestionAcademica.API.Application.DTOs
{
    public class CreateProfessorDTO
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es requerido")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "El email personal es requerido")]
        [EmailAddress(ErrorMessage = "El formato es invalido")]
        public string PersonalEmail { get; set; } = null!;

        [Required(ErrorMessage = "El email institucional es requerido")]
        [EmailAddress(ErrorMessage = "El formato es invalido")]
        public string InstitutionalEmail { get; set; } = null!;
        public string? Address { get; set; }

        [RegularExpression(@"^\d{8}$", ErrorMessage = "El numero de telefono es invalido")]
        public string? PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public string BirthDate { get; set; } = null!;
    }
}
