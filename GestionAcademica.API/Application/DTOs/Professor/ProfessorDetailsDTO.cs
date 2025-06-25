namespace GestionAcademica.API.Application.DTOs.Professor
{
    public class ProfessorDetailsDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PersonalEmail { get; set; }
        public string InstitutionalEmail { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        
        public string Status { get; set; }
        public List<ClassDTO> subjects { get; set; }
    }
}
