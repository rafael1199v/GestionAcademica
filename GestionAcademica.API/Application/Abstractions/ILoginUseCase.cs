using GestionAcademica.API.Application.DTO;

namespace GestionAcademica.API.Application.Abstractions
{
    public interface ILoginUseCase
    {
        public (string, string) Login(string email, string password);
        public void SignUp(CreateUserDTO userDto);
    }
}