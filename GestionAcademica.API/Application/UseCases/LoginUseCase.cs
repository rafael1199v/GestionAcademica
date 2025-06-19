using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Persistence.Models;

namespace GestionAcademica.API.Application.UseCases
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IHashUtility _hashUtility;
        private readonly IUserRepository _userRepository;
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IApplicantRepository _applicantRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IHrRepository _hrRepository;
        public LoginUseCase(IUserRepository userRepository, IHashUtility hashUtility,
            IAdministratorRepository administratorRepository, IApplicantRepository applicantRepository,
            IProfessorRepository professorRepository, IHrRepository hrRepository)
        {
            _userRepository = userRepository;
            _hashUtility = hashUtility;
            _administratorRepository = administratorRepository;
            _applicantRepository = applicantRepository;
            _professorRepository = professorRepository;
            _hrRepository = hrRepository;
        }

        public (string, string, string) Login(string email, string password)
        {
            UserEntity? user = _userRepository.GetByInstitutionalEmail(email)
            ?? _userRepository.GetByEmail(email)
            ?? throw new Exception("No se encontro el usuario");

            if (_hashUtility.CreateHash(password) != user.Password)
                throw new Exception("Contraseña incorrecta");

            int userRoleId = GetSpecialId(user.Id, user.RoleId);

            if (userRoleId == -1)
            {
                throw new Exception("Error obteniendo al usuario");
            }

            return (user.Id.ToString(), user.RoleId.ToString(), userRoleId.ToString());
        }

        public void SignUp(CreateUserDTO userDto)
        {
            Validate(userDto);
            Applicant user = MapDtoToUser(userDto);
            _userRepository.Add(user);
        }
        private void Validate(CreateUserDTO Dto)
        {
            UserEntity? user = _userRepository.GetByEmail(Dto.Email);

            if (user != null)
                throw new ArgumentException("El correo institutional ya existe");

            if (!DateOnly.TryParse(Dto.BirthDate, out DateOnly date))
                throw new ArgumentException("El formato de fecha es incorrecto");

            if (date > DateOnly.FromDateTime(DateTime.Now))
                throw new ArgumentException("La fecha de nacimiento no puede estar en el futuro");

        }
        private Applicant MapDtoToUser(CreateUserDTO user)
        {
            Applicant result = new Applicant
            {
                User = new User
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Password = _hashUtility.CreateHash(user.Password),
                    Address = user.Address,
                    PersonalEmail = user.Email,
                    InstitutionalEmail = "",
                    PhoneNumber = user.PhoneNumber,
                    BirthDate = DateOnly.Parse(user.BirthDate),
                    RoleId = (int)RoleEnum.Applicant
                }
            };

            return result;
        }
        private int GetSpecialId(int userId, int roleId)
        {
            switch (roleId)
            {
                case 1: //Admin
                    return _administratorRepository.GetIdByUserId(userId);

                case 2: //Professor
                    return _professorRepository.GetIdByUserId(userId);

                case 3: //Student, en desuso
                    return -1;

                case 4: //Applicant
                    return _applicantRepository.GetIdByUserId(userId);

                case 5: //Human Resources
                    return _hrRepository.GetIdByUserId(userId);

                default: //??????????????
                    return -1;
            }
        }
    }
}