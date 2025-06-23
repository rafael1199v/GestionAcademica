using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Domain.Entities;
using GestionAcademica.API.Domain.Enums;
using GestionAcademica.API.Infrastructure.Mappers;
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
        private readonly IApplicantMapper _applicantMapper;
        public LoginUseCase(IUserRepository userRepository, IHashUtility hashUtility,
            IAdministratorRepository administratorRepository, IApplicantRepository applicantRepository,
            IProfessorRepository professorRepository, IHrRepository hrRepository, IApplicantMapper applicantMapper)
        {
            _userRepository = userRepository;
            _hashUtility = hashUtility;
            _administratorRepository = administratorRepository;
            _applicantRepository = applicantRepository;
            _professorRepository = professorRepository;
            _hrRepository = hrRepository;
            _applicantMapper = applicantMapper;
        }

        public (string, string, string) Login(string email, string password)
        {
            UserEntity? user = _userRepository.GetByInstitutionalEmail(email)
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
            Applicant user = _applicantMapper.CreateUserDTOToModel(userDto);
            _applicantRepository.Add(user);
        }
        private void Validate(CreateUserDTO Dto)
        {
            UserEntity? user = _userRepository.GetByInstitutionalEmail(Dto.Email);

            if (user != null)
                throw new ArgumentException("Este correo ya existe");

            if (!DateOnly.TryParse(Dto.BirthDate, out DateOnly date))
                throw new ArgumentException("El formato de fecha es incorrecto");

            if (date > DateOnly.FromDateTime(DateTime.Now))
                throw new ArgumentException("La fecha de nacimiento no puede estar en el futuro");

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