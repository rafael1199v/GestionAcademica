using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Application.DTO;
using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;
using GestionAcademica.API.Application.Enums;

namespace GestionAcademica.API.Application
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IHashUseCase _hashUseCase;
        private readonly IUserRepository _userRepository;
        public LoginUseCase(IUserRepository userRepository, IHashUseCase hashUseCase)
        {
            _userRepository = userRepository;
            _hashUseCase = hashUseCase;
        }

        public (string, string) Login(string email, string password)
        {
            User? user = _userRepository.GetByInstitutionalEmail(email)
            ?? _userRepository.GetByEmail(email)
            ?? throw new Exception("No se encontro el usuario");
            
            if (_hashUseCase.CreateHash(password) != user.Password)
                throw new Exception("Contraseña incorrecta");

            return (user.Id.ToString(), user.RoleId.ToString());
        }

        public void SignUp(CreateUserDTO userDto)
        {
            Validate(userDto);
            Applicant user = MapDtoToUser(userDto);
            _userRepository.Add(user);
        }
        private void Validate(CreateUserDTO Dto)
        {
            User? user = _userRepository.GetByEmail(Dto.Email);

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
                    Password = _hashUseCase.CreateHash(user.Password),
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
    }
}