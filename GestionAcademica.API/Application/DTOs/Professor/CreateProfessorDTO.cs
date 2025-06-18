namespace GestionAcademica.API.Application.DTOs.Professor
{
    public class CreateProfessorDTO
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PersonalEmail { get; set; } = null!;
        public string InstitutionalEmail { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string BirthDate { get; set; } = null!;
    }
}
