using System.ComponentModel.DataAnnotations;

namespace GestionAcademica.API.Application.DTO
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
        
        [RegularExpression(@"^\d{4}\-(0?[1-4]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Ingrese un formato de fecha valida (YYYY-MM-DD)")]
        public string BirthDate { get; set; } = null!;
    }
}
