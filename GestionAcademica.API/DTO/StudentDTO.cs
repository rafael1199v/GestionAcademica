using System.ComponentModel.DataAnnotations;

namespace GestionAcademica.API.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? MiddleName { get; set; }

        public string LastName { get; set; } = null!;
 
        public string Password { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string BirthDate { get; set; } = null!;

        public int RoleId { get; set; }

        public int UserId { get; set; }
    }
}
