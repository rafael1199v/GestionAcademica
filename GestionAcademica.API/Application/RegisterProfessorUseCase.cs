using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Application.DTO;
using GestionAcademica.API.Application.Enums;
using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;

namespace GestionAcademica.API.Application
{
    public class RegisterProfessorUseCase : IRegisterProfessorUseCase
    {

        private readonly IProfessorRepository _professorRepository;

        public RegisterProfessorUseCase(IProfessorRepository administratorRepository)
        {
            _professorRepository = administratorRepository;
        }

        public ResponseProfessorDTO CreateProffesor(CreateProfessorDTO createProfessorDto)
        {
            //TODO: Crear una biblioteca de mappers para transformar de DTO a entidades de la base de datos
            
            User user = new User
            {
                Name = createProfessorDto.Name,
                LastName = createProfessorDto.LastName,
                Password = createProfessorDto.Password,
                Address = createProfessorDto.Address,
                PersonalEmail = createProfessorDto.PersonalEmail,
                InstitutionalEmail = createProfessorDto.InstitutionalEmail,
                PhoneNumber = createProfessorDto.PhoneNumber,
                BirthDate = DateOnly.Parse(createProfessorDto.BirthDate),
                RoleId = (int)RoleEnum.Professor
            };

            Professor professor = new Professor
            {
                User = user,
            };

            professor = _professorRepository.Create(professor);

            ResponseProfessorDTO responseProfessorDto = new ResponseProfessorDTO
            {
                Name = professor.User.Name,
                LastName = professor.User.LastName,
                Address = professor.User.Address,
                PersonalEmail = professor.User.PersonalEmail,
                InstitutionalEmail = professor.User.InstitutionalEmail,
                PhoneNumber = professor.User.PhoneNumber,
                BirthDate = professor.User.BirthDate.ToString(),
                RolId = professor.User.RoleId
            };

            return responseProfessorDto;
        }

    }
}
