using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Application.UseCases
{
    public class DetailProfessorUseCase : IDetailProfessorUseCase
    {
        private readonly IProfessorRepository _professorRepository;
        public DetailProfessorUseCase (IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }
        public List<ProfessorDetailsDTO> ObtainAllProfessors()
        {
            List<Professor> list = _professorRepository.GetAllWithDetails();

            List<ProfessorDetailsDTO> result = new List<ProfessorDetailsDTO>();

            foreach (var item in list)
            {
                result.Add(new ProfessorDetailsDTO
                {
                    Id = item.Id,
                    FullName = item.User.Name + " " + item.User.LastName,
                    PersonalEmail = item.User.PersonalEmail,
                    InstitutionalEmail = item.User.InstitutionalEmail,
                    Address = item.User.Address,
                    PhoneNumber = item.User.PhoneNumber,
                    Status = item.User.Status,
                    subjects = new List<ClassDTO>()
                });
            }

            return result;
        }
    }
}
