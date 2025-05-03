using GestionAcademica.API.DTO;
using GestionAcademica.API.Models;
using GestionAcademica.API.ProfessorModule.Domain;

namespace GestionAcademica.API.Administrator.Application
{
    public class RegisterProfessorUseCase : IRegisterProfessorUseCase
    {

        public IProfessorRepository _professorRepository;

        public RegisterProfessorUseCase(IProfessorRepository administratorRepository)
        {
            _professorRepository = administratorRepository;
        }

        public void CreateProffesor(ProfessorDTO professorDTO)
        {
            //TODO: Crear una biblioteca de mappers para transformar de DTO a entidades de la base de datos

            User user = new User
            {
                Name = professorDTO.Name,
                MiddleName = professorDTO.MiddleName,
                LastName = professorDTO.LastName,
                Email = professorDTO.Email,
                Password = professorDTO.Password,
                PhoneNumber = professorDTO.PhoneNumber,
                BirthDate = DateOnly.Parse(professorDTO.BirthDate),
                RoleId = professorDTO.RoleId
            };

            Professor professor = new Professor
            {
                User = user,
            };

            _professorRepository.Create(professor);
        }

    }
}
