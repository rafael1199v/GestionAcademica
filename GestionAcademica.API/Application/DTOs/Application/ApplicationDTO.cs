namespace GestionAcademica.API.Application.DTOs.Application
{
    public class ApplicationDTO
    {
        // public string VacancyName { get; set; }
        // public string VacancyDesc { get; set; }
        // public string Status { get; set; }
        // public string ApplicantName { get; set; }
        // public string OwnerName { get; set; }
        // public int FileQtty { get; set; }
        // // public ICollection<File> Files { get; set; } = new List<File>();
        // public int Id { get; set; }
        // public int VacancyId { get; set; }
        // public int StatusId { get; set; }
        // public int ApplicantId { get; set; }
        // public int OwnerId { get; set; }
        
        public int Id { get; set; }
        public int VacancyId { get; set; }
        public int ApplicantId { get; set; }
        public int StatusId { get; set; }
        public string? VacancyName { get; set; }
        public string? VacancyDescription { get; set; }
        public string? VacancyCareerName { get; set; }
        public string? ApplicantName { get; set; }
        public string? AdministratorName { get; set; }
        
    }
}