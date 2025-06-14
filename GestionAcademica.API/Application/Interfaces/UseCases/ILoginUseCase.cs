using GestionAcademica.API.Application.DTOs;

namespace GestionAcademica.API.Application.Interfaces.UseCases
{
    public interface ILoginUseCase
    {
        public (string, string) Login(string email, string password);
        public void SignUp(CreateUserDTO userDto);
    }
}