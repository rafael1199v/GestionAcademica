using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistance.Models;

namespace GestionAcademica.API.Application.UseCases
{
    public class RegisterProfessorUseCase : IRegisterProfessorUseCase
    {

        private readonly IProfessorRepository _professorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHashUtility _hashUtility;

        public RegisterProfessorUseCase(IProfessorRepository administratorRepository, IUserRepository userRepository, IHashUtility hashUtility)
        {
            _professorRepository = administratorRepository;
            _userRepository = userRepository;
            _hashUtility = hashUtility;
        }

        public ResponseProfessorDTO CreateProffesor(CreateProfessorDTO createProfessorDto)
        {
            ValidateProfessor(createProfessorDto);
            
            Professor professor = MapCreateProfessorDtoToProfessor(createProfessorDto);
            professor = _professorRepository.Add(professor);
            ResponseProfessorDTO responseProfessorDto = MapProfessorToResponseProfessor(professor);

            return responseProfessorDto;
        }

        private Professor MapCreateProfessorDtoToProfessor(CreateProfessorDTO createProfessorDto)
        {
            Professor professor = new Professor
            {
                User = new User
                {
                    Name = createProfessorDto.Name,
                    LastName = createProfessorDto.LastName,
                    Password = _hashUtility.CreateHash(createProfessorDto.Password),
                    Address = createProfessorDto.Address,
                    PersonalEmail = createProfessorDto.PersonalEmail,
                    InstitutionalEmail = createProfessorDto.InstitutionalEmail,
                    PhoneNumber = createProfessorDto.PhoneNumber,
                    BirthDate = DateOnly.Parse(createProfessorDto.BirthDate),
                    RoleId = (int)RoleEnum.Professor
                }

            };

            return professor;
        }
        
        private ResponseProfessorDTO MapProfessorToResponseProfessor(Professor professor)
        {
            ResponseProfessorDTO responseProfessorDto = new ResponseProfessorDTO
            {
                Id = professor.Id,
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


        private void ValidateProfessor(CreateProfessorDTO createProfessorDto)
        {
            User? user = _userRepository.GetByInstitutionalEmail(createProfessorDto.InstitutionalEmail);

            if (user != null)
                throw new ArgumentException("El correo institutional ya existe");
            
            if (!DateOnly.TryParse(createProfessorDto.BirthDate, out DateOnly date))
                throw new ArgumentException("El formato de fecha es incorrecto");
            
            if (date > DateOnly.FromDateTime(DateTime.Now))
                throw new ArgumentException("La fecha de nacimiento no puede estar en el futuro");
            
        }

    }
}
