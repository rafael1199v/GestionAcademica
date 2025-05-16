namespace GestionAcademica.API.Application.Abstractions
{
    public interface ILoginUseCase
    {
        public string Login(string email, string password);
    }
}