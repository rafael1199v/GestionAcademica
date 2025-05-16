using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Domain;
using GestionAcademica.API.Models;

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
        public string Login(string email, string password)
        {
            User? user = _userRepository.GetByInstitutionalEmail(email) ?? throw new Exception("No se encontro el usuario");
            if (_hashUseCase.CreateHash(password) == user.Password)
                throw new Exception("Contraseña incorrecta");

            return "ok";
            // return user.Token;
            // TODO: añadir función de token
        }
    }
}